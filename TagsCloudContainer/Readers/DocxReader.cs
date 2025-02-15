﻿using NPOI.XWPF.UserModel;
using TagsCloudContainer.Interfaces;
using TagsCloudContainer.Utility;

namespace TagsCloudContainer.Readers
{
    public class DocxReader : IFileReader
    {
        public Result<IEnumerable<string>> ReadWords(string filePath)
        {
            var words = new List<string>();

            try
            {
                using (var doc = new XWPFDocument(File.OpenRead(filePath)))
                {
                    foreach (var paragraph in doc.Paragraphs)
                    {
                        words.AddRange(paragraph.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    }
                }

                return Result.Ok<IEnumerable<string>>(words);
            }
            catch (Exception ex)
            {
                return Result.Fail<IEnumerable<string>>($"Error reading .docx file: {ex.Message}");
            }
        }
    }
}
