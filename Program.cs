using System;
using System.IO;

namespace trycatchfinally
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "test.txt";
            
            // case 1            
            //StreamWriter sw1 = new StreamWriter(filePath);
            //sw1.WriteLine("miss dispose");

            // case 2
            using (StreamWriter sw1 = new StreamWriter(filePath))
            {
                sw1.WriteLine("use using");
                Console.WriteLine("this is Using");
            }
            
            StreamWriter sw = null;
            try
            {                
                // 파일스트림을 사용하고 아직 해제 하지 않은 상태
                sw = new StreamWriter(filePath);
                sw.WriteLine("Hello World");

                // 예외상황을 강제로 발생 시켜줌
                object obj = null;
                int temp = (int)obj;
            }   
            catch (Exception e)                      
            {
                // 예외 상황에 대해서 출력
                Console.WriteLine(e.Message);
            }
            finally
            {
                // 예외가 발생하더라도 리소스 해제를 보장 함
                sw.Dispose();
                Console.WriteLine("finally");
            }
        }
    }
}
