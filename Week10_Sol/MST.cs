public class MST
{
    public static double getMSTCost(double [,] dataset, int [] node)
    {
        double mstCost = 0.00;
        for (int i = 1; i < dataset.GetLength(0); i++)
        {
            mstCost += dataset[i, node[i]];
        }
         return mstCost;   
    }

    private static int MinKey(double[] key, bool[] mst_set, int verticesCount)
    {
        double  min = double.MaxValue; //default the minimum value of min to the max value 
        int minIndex = 0;

        //checking all vertices from this array and get the min value and index respectively
        for (int v = 0; v < verticesCount; v++)
        {
            if (mst_set[v] == false && key[v] < min) //updating the false index (node) with the least cost
            {
                min = key[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

    private static void Print(int[] parent, double[,] dataset)
    {
        Console.WriteLine("Edge     Weight");
        for (int i = 1; i < dataset.GetLength(0); i++)
            Console.WriteLine("{0} - {1}    {2}", parent[i], i, dataset[i, parent[i]]);
    }

    public static int [] Prim(double[,] dataset)
    {
        int[] parent = new int[dataset.GetLength(0)];
        double[] key = new double[dataset.GetLength(0)]; //this array is used to store the edge values
        bool[] mstSet = new bool[dataset.GetLength(0)]; //we only tag true in this array if the nodes have the least edges values

        for (int i = 0; i < dataset.GetLength(0); i++)
        {
            key[i] = double.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0.00; //set to 0.00 so that we can start from this point when searching the min key
        parent[0] = -1; //we default the first value of the node to -1

        for (int count = 0; count < dataset.GetLength(0) - 1; count++)
        {
            int u = MinKey(key, mstSet, dataset.GetLength(0)); //the first index value definitely 0 because we have set key[0] = 0.00
            // Console.WriteLine("u : "+u);
            mstSet[u] = true;

            for (int v = 0; v < dataset.GetLength(0); v++)
            {
                if (Convert.ToBoolean(dataset[u, v]) && mstSet[v] == false && dataset[u, v] < key[v])
                {
                    // Console.WriteLine("u : "+u +",  v : "+v);
                    // Console.WriteLine("dataset[u, v] vs key[v] :  "+dataset[u, v]+" vs "+key[v]);
                    parent[v] = u; //this is where we store the index of the node with the least key/edge value
                    key[v] = dataset[u, v];
                    // Console.WriteLine("parent[v] : "+parent[v]);
                }
            }
            Console.WriteLine();
        }
        //Print(parent, dataset);
        return parent;
    }
}