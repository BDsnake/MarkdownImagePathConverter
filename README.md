# Markdown Image Path Converter

## 简介

Markdown Image Path Converter 是一个 Windows 窗体应用程序，旨在帮助用户快速替换 Markdown 文件中的图片路径。用户可以将使用图床的图片链接替换为本地相对路径，或将本地相对路径替换为图床地址，从而方便地管理和使用 Markdown 文件中的图片。

## 功能

- 自动生成本地路径（相对于 Markdown 文件的目录）。
- 将图床地址替换为本地相对路径。
- 将本地路径替换为图床地址。
- 用户友好的界面，简单易用。

## 使用说明

1. **选择 Markdown 文件**：点击“选择文件”按钮，选择需要处理的 Markdown 文件。
2. **输入图床地址**：在“图床地址”输入框中输入图片的图床链接（不需要以 `/` 结尾）。
3. **输入本地路径**：在“本地路径”输入框中输入本地文件夹路径（可以留空，使用自动生成）。
4. **自动生成本地路径**：点击“自动生成本地路径”按钮，根据 Markdown 文件的名称生成本地路径（格式为 `文件名.assets`）。
5. **执行替换**：
   - 点击“替换为本地路径”按钮，将图床地址替换为本地相对路径。
   - 点击“替换为图床路径”按钮，将本地路径替换为图床地址。

## 安装

1. 下载源代码或克隆本项目：
   ```bash
   git clone https://github.com/BDsnake/MarkdownImagePathConverter.git
2. Release
[https://github.com/BDsnake/MarkdownImagePathConverter/releases/tag/v1.0.0](https://github.com/BDsnake/MarkdownImagePathConverter/releases/tag/v1.0.0)

## 界面展示

![image-20241009105914113](README.assets/image-20241009105914113.png)

