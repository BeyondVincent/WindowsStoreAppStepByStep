using System.Collections.Generic;

namespace BV_FlipView
{
    class MainPageViewModel
    {
        public List<ImageData> itemsList { get; set; }

        public MainPageViewModel()
        {
            itemsList = new List<ImageData>();
            itemsList.Add(new ImageData("冬季", "image/1.jpg", "我在等待\n落雪的声音（1）"));
            itemsList.Add(new ImageData("冬季", "image/2.jpg", "我在等待\n落雪的声音（2）"));
            itemsList.Add(new ImageData("冬季", "image/3.jpg", "我在等待\n落雪的声音（3）"));
            itemsList.Add(new ImageData("冬季", "image/4.jpg", "我在等待\n落雪的声音（4）"));
            itemsList.Add(new ImageData("冬季", "image/5.jpg", "我在等待\n落雪的声音（5）"));
            itemsList.Add(new ImageData("冬季", "image/6.jpg", "我在等待\n落雪的声音（6）"));
            itemsList.Add(new ImageData("冬季", "image/7.jpg", "我在等待\n落雪的声音（7）"));
            itemsList.Add(new ImageData("冬季", "image/8.jpg", "我在等待\n落雪的声音（8）"));
            itemsList.Add(new ImageData("冬季", "image/9.jpg", "我在等待\n落雪的声音（9）"));
            itemsList.Add(new ImageData("冬季", "image/10.jpg", "我在等待\n落雪的声音（10）"));
            itemsList.Add(new ImageData("冬季", "image/11.jpg", "我在等待\n落雪的声音（11）"));
            itemsList.Add(new ImageData("冬季", "image/12.jpg", "我在等待\n落雪的声音（12）"));
            itemsList.Add(new ImageData("冬季", "image/13.jpg", "我在等待\n落雪的声音（13）"));
            itemsList.Add(new ImageData("冬季", "image/14.jpg", "我在等待\n落雪的声音（14）"));
            itemsList.Add(new ImageData("DevDiv", "image/15.png", "移动开发尽在\nDevDiv.com"));
        }
    }
}
