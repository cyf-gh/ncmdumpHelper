# ncmdumpHelper

享受一键将ncm转化为MP3。

![1](1.gif)



## 事由

  日常随手将网易云上下载的歌曲丢进Walkman，但等到回头听的时候发现有好多歌都不见了😨，文件夹都是空的，这无非是歌曲格式读不出或者是歌曲没放进去。打开电脑一看，wdnmd原来是网易云自家的坑爹ncm格式，于是乎迅速百度一下寻找一下对策。

  每一次手动拖动又太复杂，于是乎工欲善其事必先利其器，随手写了个批量自动转化的工具。

## 编译运行

请将

https://raw.githubusercontent.com/NoColor2/ncmdump/master/main.exe

复制到程序根目录下，文件名必须为main.exe。

```bash
cd ~
git clone https://github.com/cyf-gh/ncmdumpHelper.git
curl https://raw.githubusercontent.com/NoColor2/ncmdump/master/main.exe
cp ./main.exe ~/ncmdumpHelper/ncmdump/ncmdump.App/bin/Debug
cp ./main.exe ~/ncmdumpHelper/ncmdump/ncmdump.App/bin/Release
```

## 引用

https://github.com/anonymous5l/ncmdump

https://github.com/NoColor2/ncmdump