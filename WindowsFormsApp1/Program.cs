using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /*Class netNode - Individual nodes that make up the test network -
     * Each node keeps track of it's own ID, neighbhors, 
     * the previous neighbhor with the shortest path back to source, 
     * its own distance from the source, and its own working/non-working status.
     * 
     * 
    */
    public class netNode
    {
        public int ID; //Current node's ID
        public int [] neighbors; //Array of neighbhor ID numbers 
        public int prevID; //ID of previous best node for Djirkstra
        public int dist;    // Distance for Djirkstra's alg
        public bool isGood; //Status of the node - Broken or working


        //netNode constructor - Creates new netNodes of ID I, assigns neighbhors.
        public netNode(int I)
        {
            ID = I;
            dist = 999;
            prevID = -2;
            isGood = true;
            //Assigns static neighbhors based on ID to generate graph
            switch(ID)
            {
                case 0:
                    neighbors = new int[2] { 12, 15 } ;
                    break;
                case 1:
                    neighbors = new int[2] { 12, 13 };
                    break;
                case 2:
                    neighbors = new int[3] { 13, 16, 14 };
                    break;
                case 3:
                    neighbors = new int[2] { 14, 17 };
                    break;
                case 4:
                    neighbors = new int[3] { 15, 18, 21 };
                    break;
                case 5:
                    neighbors = new int[3] { 18, 22, 19 };
                    break;
                case 6:
                    neighbors = new int[4] { 19, 16, 20, 23 };
                    break;
                case 7:
                    neighbors = new int[3] { 17, 20, 24 };
                    break;
                case 8:
                    neighbors = new int[2] { 21, 25 };
                    break;
                case 9:
                    neighbors = new int[2] { 22, 25 };
                    break;
                case 10:
                    neighbors = new int[2] { 23, 26 };
                    break;
                case 11:
                    neighbors = new int[2] { 26, 24 };
                    break;
                case 12:
                    neighbors = new int[2] { 0, 1 };
                    break;
                case 13:
                    neighbors = new int[2] { 1, 2 };
                    break;
                case 14:
                    neighbors = new int[2] { 2, 3 };
                    break;
                case 15:
                    neighbors = new int[2] { 0, 4 };
                    break;
                case 16:
                    neighbors = new int[2] { 2, 6 };
                    break;
                case 17:
                    neighbors = new int[2] { 3, 7 };
                    break;
                case 18:
                    neighbors = new int[2] { 4, 5 };
                    break;
                case 19:
                    neighbors = new int[2] { 5, 6 };
                    break;
                case 20:
                    neighbors = new int[2] { 6, 7 };
                    break;
                case 21:
                    neighbors = new int[2] { 4, 8 };
                    break;
                case 22:
                    neighbors = new int[2] { 5, 9 };
                    break;
                case 23:
                    neighbors = new int[2] { 6, 10 };
                    break;
                case 24:
                    neighbors = new int[2] { 7, 11 };
                    break;
                case 25:
                    neighbors = new int[2] { 8, 9 };
                    break;
                case 26:
                    neighbors = new int[2] { 10, 11 };
                    break;
            }
        }

    } 
    /* Class nodeGraph
     * Contains the set of nodes that make up the test network, along with user defined source and destination nodes
     * 
     * Member functions:
     *        void solve() - Attempts to find a path between two nodes after picking broken nodes. User input set in UI.
     *        void reset() - Garbage collection function to reset container variables between solve() attempts.
  
     */
    public class nodeGraph
    {
        public netNode[] graphNet;
        public int source; //Desired source node
        public int dest; //Desired destination node
        public int rz; //Number of failed nodes
        public List<int> solution = new List<int>(); //Tracks path of one of the optimized solutions
        public List<int> badNodes = new List<int>(); //Keeps track of failed nodes
        public bool solFound; // Status variable for if the algorithm was able to find a path
        public nodeGraph ()
        {
            //Loop to generate our network of nodes - Properties of each node are defined in the netNode constructor
            graphNet = new netNode[27];
            for (int currentID = 0; currentID < 27; currentID++)
            {
                graphNet[currentID] = new netNode(currentID);
                //Console.WriteLine("{0} has been created with neighbor {1}", graphNet[currentID].ID, graphNet[currentID].neighbors[0]);
            }
        } 




        /*  void reset()
            Garbage cleanup function to be called between solve attempts
            Clears container lists and resets distances of graph nodes to sentinel value
            Also resets bad nodes
            */
        public void reset()
        {
            solution.Clear();
            badNodes.Clear();
            for ( int z = 0; z < 27; z++ )
            {
                graphNet[z].dist = 999;
                graphNet[z].isGood = true;
            }
        }
        
        /*   void solve()
            Generates a user specified number of failed nodes in random positions, then attempts to find a solution

            Implements Djirkstra's algorithm to find a shortest path to the destination from source node.

            If a solution is found, the path remains in the solution list.
            If a solution is not found, the solFound flag is set to false and the solution list remains empty.
        */
        public void solve()
        {
            Random rnd = new Random();
            solFound = true;
            int lowest = 1000;
            int temp = 0;
            int lowIndex = 0;
            int final = 0;

            //Randomly pick rz nodes to fail
            for ( int j = 0; j < rz; j++ )
            {
                final = rnd.Next(0, 27); 
                while ( final == source || final == dest || badNodes.Contains(final) )
                {
                    final = rnd.Next(0, 27);
                }
                //Console.WriteLine(" {0} ", final);
                if (graphNet[final].isGood)
                {
                    graphNet[final].isGood = false;
                    badNodes.Add(final);//Adds failed nodes to list of failed nodes
                }
            }
               
            
            //Add all working nodes to the graph for exploration
            List<int> unexploredNodes = new List<int>();
            for(int index = 0; index < 27; index++)
            {
                    unexploredNodes.Add(index);//Populates list of unexplored nodes
            } 
            graphNet[source].dist = 0;
            graphNet[source].prevID = -1;
            while ( unexploredNodes.Count != 0 )//Loops through all unexplored nodes until none are left
            {
                lowest = 1000;
                lowIndex = 0;
                temp = 0;
                foreach (int x in unexploredNodes)//Loops through each unexplored node and removes the node with the lowest distance
                {
                    if ( ( graphNet[x].dist < lowest ) && (graphNet[x].isGood))
                    {
                        lowest = graphNet[x].dist;
                        lowIndex = x;
                    }
        
                }
                unexploredNodes.Remove(lowIndex);
                if ( lowIndex == dest )//If destination is at low index, a solution has been found
                {
                    int counter = 0;

                    solution.Add(dest);
                    solFound = true;
                    while ( graphNet[lowIndex].prevID != -1 && counter < 27)
                    {
                        if (!graphNet[lowIndex].isGood || graphNet[lowIndex].prevID == -2) //If the only solution contains bad nodes, there is no solution found
                        {
                            Console.WriteLine("solFound set to false inside dest loop");
                            solution.Clear();
                            solFound = false;
                            return;
                        }

                            solution.Add(graphNet[lowIndex].prevID); //Each node is added to the list containing the most efficient path
                            lowIndex = graphNet[lowIndex].prevID;
                            counter++;
                    }  
                    if (solution.Count == 2 || lowIndex != source)//The solution is checked for bad nodes again, otherwise destination is successfully found
                    {
                        solution.Clear();
                        solFound = false;
                        return;
                    }

                    Console.WriteLine("SOLUTION:");
                    solution.Reverse();
                    foreach ( int z in solution )
                    {
                        Console.Write(" {0} ", z);
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("BAD NODES:");
                    foreach ( int h in badNodes )
                    {
                        Console.WriteLine(" {0} ", h);
                    }
                    Console.WriteLine("Destination has been found.");
                    return;
                }
                foreach (int v in graphNet[lowIndex].neighbors)//Each neighbor is evaluated, and the distance of the neighbor is updated if the current node is a better path
                {
                    temp = graphNet[lowIndex].dist + 1; 
                    if ( temp < graphNet[v].dist )
                    {
                        graphNet[v].dist = temp;
                        graphNet[v].prevID = lowIndex;
                    }
                }
            }
            solFound = false;
            solution.Clear();
            Console.WriteLine("solFound set to false at while termination");
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
