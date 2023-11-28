public class Experiment
{
    public static void runExp() 
    {
        double [,] results = new double[25,3];
        int i=0;

        for (int dataset=1000; dataset<10000; dataset+=2000)
        {
            Console.WriteLine("::Experiment for Dataset {0}::", dataset);
            string fileName = "mstData_"+dataset+".csv";
            double [,] mstData = ReadWriteFile.readCSV(fileName);
            Console.WriteLine("Data size : "+mstData.GetLength(0));
            
            for (int exp=1; exp<6; exp++)
            {
                Console.WriteLine("Running Experiment Number "+exp);
                // Console.WriteLine(i);
                DateTime start = DateTime.Now;
               
               
                double [,] data = ReadWriteFile.readCSV(fileName);
                int [] mstRes = MST.Prim(data);
                Console.WriteLine("MST Cost : "+MST.getMSTCost(mstData, mstRes));
                
                
                DateTime end = DateTime.Now;

                long duration = (long) (end - start).TotalMilliseconds;
                double sec = duration/1000.00;
                Console.WriteLine("Second : "+sec);
                
                results[i,0] = dataset;
                results[i,1] = exp;
                results[i,2] = sec;
                i++;
            }
        }
       ReadWriteFile.writeExpResults(results);
    }
}

//©Zairul Mazwan©