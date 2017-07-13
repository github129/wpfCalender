// <copyright file="ImgApi.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FlickrAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using FlickrNet;

    /// <summary>
    /// イメージAPIを扱うクラス
    /// </summary>
    public class ImgAPI
    {
        private Flickr flickr;
        private string flickrApiKey = "0383912f104ae322052b87aae3ac9d2b";
        private PhotoCollection photos;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImgAPI"/> class.
        /// </summary>
        public ImgAPI()
        {
            this.flickr = new Flickr(this.flickrApiKey);
            this.photos = new PhotoCollection();
        }

        /// <summary>
        /// 写真のURLを取得するメソッド
        /// タグの中からランダムに取得してくる
        /// </summary>
        /// <returns>ingUrl 画像URL</returns>
        public string GetImg()
        {
            Random random = new Random();
            PhotoSearchOptions opt = new PhotoSearchOptions();
            opt.Tags = "Mountain Background orange";
            opt.TagMode = TagMode.AllTags;
            this.photos = this.flickr.PhotosSearch(opt);
            var imgNumber = random.Next(this.photos.Count);
            var imgUrl = this.photos[imgNumber].LargeSquareThumbnailUrl;
            return imgUrl;
        }

    }
}
