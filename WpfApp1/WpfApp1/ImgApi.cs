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
    using System.Windows;
    using FlickrNet;

    public class ImgApi
    {
        private Flickr flickr;
        private string flickrApiKey = "0383912f104ae322052b87aae3ac9d2b ";

        private int index;

        public ImgApi()
        {
            index = 0;
            flickr = new Flickr(flickrApiKey);
        }

    }
}
