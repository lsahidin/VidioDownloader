# Streaming video downloader

Help user to collect their favorite movie in some click from Vidio.com and Terafile stream video

## Getting Started

This project build on framework from Microsoft Visual Studio .Net using module System.Net Webclient, actually computer play movie stream by download many of chunk files from server

### Development Prerequisites

Of course, we need Microsoft Visual Studio as development tools with installed .Net Framework 3.5 or later, ffmpeg.exe that you can get from [offical website](https://ffmpeg.org/) and a glass of coffee to shake our mind

### Step for Testing

**Version 1.0.0.0 - 2017**
* Open movie in [vidio.com](http://www.vidio.com/) 
* Right click on page then choose View page source
* Find keyword "vjs_playlist.m3u8"
* Click that link to download .m3u8 file
* Run Vidio Downloader and browse .m3u8 file to get the list of streaming file

**Version 1.0.2.0 - latest update**
* No more to find .m3u8 file
* to download from [vidio.com](http://www.vidio.com), just copy/paste video id such as picture below:
![vidiourl](https://user-images.githubusercontent.com/12827784/57500462-b5994280-730d-11e9-9569-6adfc7d4b54a.jpg)
* Whereas to download from Terafile.net, you can copy full url such as picture below 
![teraurl](https://user-images.githubusercontent.com/12827784/57500499-d82b5b80-730d-11e9-910e-01745fe58fa7.jpg)
* But some website video streaming using JW player for terafile, while video playing try to right click on player then choose to menu "Terafile" such as attached picture, then you will redirect to new window with the url you can paste to downloader <br />
![terafile](https://user-images.githubusercontent.com/12827784/57500523-e4afb400-730d-11e9-9867-258e5bbee771.jpg)


## Compiled project
Wanna try? please dowload app from [this link](https://github.com/lsahidin/VidioDownloader/releases/download/1.0.2.0/Vidio.zip)


## Author

* **Luqman Sahidin** - *Initial work* - [lsahidin](https://github.com/lsahidin)


## License

This project is licensed under Creative Commons - see the [Attribution 4.0 International](http://creativecommons.org/licenses/by/4.0/) file for details.