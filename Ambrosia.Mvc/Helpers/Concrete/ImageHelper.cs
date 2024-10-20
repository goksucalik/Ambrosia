﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Ambrosia.Entities.ComplexTypes;
using Ambrosia.Entities.Dtos;
using Ambrosia.Mvc.Helpers.Abstract;
using Ambrosia.Shared.Utilities.Extensions;
using Ambrosia.Shared.Utilities.Results.Abstract;
using Ambrosia.Shared.Utilities.Results.ComplexTypes;
using Ambrosia.Shared.Utilities.Results.Concrete;

namespace Ambrosia.Mvc.Helpers.Concrete
{
    public class ImageHelper:IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private const string imgFolder = "img";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null)
        {
            try
            {
                folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;
                if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
                {
                    Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
                }
                string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
                string fileExtension = Path.GetExtension(pictureFile.FileName);
                Regex regex = new Regex("[*'\",._&#^@]");
                name = regex.Replace(name, string.Empty);
                DateTime dateTime = DateTime.Now;
                string newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
                var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await pictureFile.CopyToAsync(stream);
                }
                string nameMessage = pictureType == PictureType.User
                    ? $"{name} adlı kullanıcının resmi başarıyla yüklendi."
                    : $"{name} adlı makalenin resmi başarıyla yüklendi.";
                return new DataResult<ImageUploadedDto>(ResultStatus.Success, nameMessage, new ImageUploadedDto
                {
                    FullName = $"{folderName}/{newFileName}",
                    OldName = oldFileName,
                    Extension = fileExtension,
                    FolderName = folderName,
                    Path = path,
                    Size = pictureFile.Length
                });
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayın veya konsola yazdırın
                Console.WriteLine(ex.Message);
                return new DataResult<ImageUploadedDto>(ResultStatus.Error, "Resim yüklenirken bir hata oluştu.", null);
            }
        }


        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success,imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error,$"Böyle bir resim bulunamadı.",null);
            }
        }
    }
}
