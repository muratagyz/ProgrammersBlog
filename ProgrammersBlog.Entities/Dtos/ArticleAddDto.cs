﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleAddDto
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Title { get; set; }


        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Content { get; set; }


        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Thumbnail { get; set; }


        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }


        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoAuthor { get; set; }


        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoDescription { get; set; }


        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoTags { get; set; }


        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        [DisplayName("Aktif Mi")]
        [Required(ErrorMessage = "{0} Boş geçilmemelidir.")]
        public bool IsActive { get; set; }
    }
}
