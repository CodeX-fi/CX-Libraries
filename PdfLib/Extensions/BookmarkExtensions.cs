﻿using CX.PdfLib.Implementation.Data;
using CX.PdfLib.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CX.PdfLib.Extensions
{
    public static class BookmarkExtensions
    {
        /// <summary>
        /// Return bookmark start page (ie. destination)
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        public static int StartPage(this IBookmark bookmark)
        {
            return bookmark.Pages[0];
        }
        /// <summary>
        /// Return the end page of bookmark's range
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        public static int EndPage(this IBookmark bookmark)
        {
            return bookmark.Pages.Last();
        }
        /// <summary>
        /// Adjust the level of all bookmarks in an <see cref="IList{ILeveledBookmark}"/>.
        /// </summary>
        /// <param name="originals"></param>
        /// <param name="adjustment">Amount to adjust (positive or negative)</param>
        /// <remarks>Bookmark level cannot be lower than 1. Bookmarks will be adjusted
        /// to level 1, if adjustment would bring it lower. This can be used to level all
        /// bookmarks to level 1.</remarks>
        /// <returns></returns>
        internal static IList<ILeveledBookmark> AdjustLevels(this IList<ILeveledBookmark> originals, 
            int adjustment)
        {
            List<ILeveledBookmark> adjusted = new List<ILeveledBookmark>();
            foreach (ILeveledBookmark bookmark in originals)
            {
                int adjLevel = bookmark.Level + adjustment > 0 ? bookmark.Level + adjustment : 1;
                adjusted.Add(new LeveledBookmark(adjLevel, bookmark.Title,
                    bookmark.Pages));
            }

            return adjusted;
        }
    }
}
