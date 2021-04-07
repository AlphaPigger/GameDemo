using System;
using System.Collections.Generic;
using System.Text;

namespace DemoStartUp.Domain
{
    public class StartUp
    {
        private InitializeArticle _initializeArticle = new InitializeArticle();
        public void Start()
        {
            Console.WriteLine("---Game Start!---\n");

            _initializeArticle.InitializeData("Toothpick");
            _initializeArticle.Rendering();

            Console.ReadLine();
        }
    }
}
