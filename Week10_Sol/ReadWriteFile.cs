using System.ComponentModel;
using System.Data;
using System.Runtime.ExceptionServices;

public class ReadWriteFile {
	
	public static double [,]  genData (int n) {
		
		double [,] res = new double [n,n];

		Random rd = new Random ();

		for (int i=0; i<n; i++)
		{
			for (int j=i; j<n; j++)
			{
				double val = Math.Round(rd.NextDouble()*100,2);
				res[i,j] = val;
				res[j,i] = val;
				if (i==j)
					res[i,j] = 0.00;
			}
		}
		return res;
	}
	
	public static void writeResult(double [,] result, int size) 
	{
		
		string filename = "mstData_"+size+".csv";

		using(StreamWriter sw = new StreamWriter(filename))
		{
			for (int i=0; i<result.GetLength(0); i++)
			{
				for (int j=0; j<result.GetLength(1); j++)
				{
					sw.Write(result[i,j]);
					if(j<result.GetLength(1)-1)
						sw.Write(",");
				}
				sw.WriteLine();
			}
		}
	}
	
	public static double [,] readCSV (string fileName) {
		
		String file = @"/Users/zairulmazwan/Dotnet/ADSLabWeek10_Sol/Week10_Sol/"+fileName;
		double [,] graph = null;
		int row=0, col=0;
		
		using(StreamReader sr = new StreamReader(file))
		{
			while (!sr.EndOfStream)
			{
				row++;
				var line = sr.ReadLine();
				var values = line.Split(",");
				col = values.Length;

			}
		}

		graph = new double [row,col];


		using(StreamReader sr = new StreamReader(file))
		{
			string line = null;
			int i=0;
			while  ((line = sr.ReadLine()) != null)
			{
				var val = line.Split(",");
				for (int j=0; j<val.Length; j++)
				{
					graph[i,j] = Double.Parse(val[j]);
					
				}
				i++;
			}
		}
		return graph;	
	}
	
	public static void printArray (double [,] array) {
		
		for (int i=0; i<array.GetLength(0); i++)
		{
			for (int j=0; j<array.GetLength(1); j++)
			{
				Console.Write(array[i,j]);
				Console.Write(" ");
			}
			Console.WriteLine();
		}
	}

	public static void genExperimentDatasets()
	{
		for (int i=1000; i<10000; i+=2000)
		{
			//Console.WriteLine("Dataset_"+i);
			double [,] data =genData(i);
			writeResult(data,i);
		}
		
	}

	public static void writeExpResults (double [,] results)
	{
		string file = "result.csv";

		using (StreamWriter sw = new StreamWriter(file))
		{
			for (int i=0; i<results.GetLength(0); i++)
			{
				for (int j =0; j<results.GetLength(1); j++)
				{
					sw.Write(results[i,j]);
					if (j<results.GetLength(1)-1)
						sw.Write(",");
				}
				sw.WriteLine();
			}
		}
	}	
}
//©Zairul Mazwan©