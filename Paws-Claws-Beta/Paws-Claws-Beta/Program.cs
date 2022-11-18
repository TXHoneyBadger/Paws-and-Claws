/*
 * Paws and Claws
 * 
 * By: Krystal Gonzales
 * Ernesto Cardenas
 * 
 * C#  MSSA Project #1.
 * 
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Paws_Claws_Beta
{
    class Program
    {
        public static string UserName = "";
        public static string petType = "";
        public static string petName = "";
        public static string petBreed = "";
        public static string petGender = "";


        static void Main(string[] args)
        {
            // StartConsole method is called
            StartConsole.TitlePage();
        }

    }


    class StartConsole
    {

        public static void TitlePage()
        {
            Console.WriteLine(@"
   _____                                        _    _____ _                    
 |  __ \                       /\             | |  / ____| |                   
 | |__) |_ ___      _____     /  \   _ __   __| | | |    | | __ ___      _____ 
 |  ___/ _` \ \ /\ / / __|   / /\ \ | '_ \ / _` | | |    | |/ _` \ \ /\ / / __|
 | |  | (_| |\ V  V /\__ \  / ____ \| | | | (_| | | |____| | (_| |\ V  V /\__ \
 |_|   \__,_| \_/\_/ |___/ /_/    \_\_| |_|\__,_|  \_____|_|\__,_| \_/\_/ |___/ ");
            Console.WriteLine("");


            Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀    ⣀⣴⠾⠿⣷⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣶⣶⣿⠉⠀⠀⠈⢻⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⣀⣘⢿⣿⠿⠿⠿⣿⣷⣀⠀⠀⠀⠹⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣷⣆⣠⣶⠾⠿⠛⠛⠉⠉⠉⠉⠉⠀⣀⠀⠀⠈⠙⢿⡄⠀⠀⠀⠘⢿⣆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣩⠙⠻⠷⣶⣄⠻⣄⠀⠀⠀⠈⢻⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣾⡿⠷⠒⠃⢰⣿⣿⣿⠋⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⠀⠀⠈⠻⣷⡜⣦⡀⠀⠀⠀⠙⢿⣆⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⠋⠁⠀⠀⠀⠀⣾⣿⡿⠁⢠⣴⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠸⣿⡘⣿⣆⠀⠀⠀⠀⠛⣷⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠃⠀⠀⠀⠀⣤⢸⣿⡿⠁⢠⣿⡏⠀⠉⠙⠛⠿⣶⣄⠀⠀⠀⠀⢸⣇⣠⠶⣶⣄⠀⠀⢻⣇⠈⠻⣷⣄⠀⠀⠀⠈⠻⣷⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠇⠀⠀⠀⠀⣼⠃⢸⣿⡇⠀⣾⡟⠀⠀⠀⠀⠀⠀⠈⠻⣷⡄⠀⠀⠘⣿⣇⠀⣻⣿⡄⠀⢸⣿⣀⣤⣼⣿⣿⣶⣦⣤⣀⠈⠻⣄⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡟⠀⠀⠀⠀⠀⣿⠀⢸⣿⠃⠀⣿⡇⠀⠀⣠⣤⣤⣄⠀⠀⠈⢻⣇⠀⠀⠹⣿⣿⣿⣿⠁⣠⣼⣿⣿⣿⣿⣿⣿⣿⣿⡿⠻⣿⣷⣌⠂⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡟⠁⠀⠀⠀⠀⠀⣿⡄⠈⠛⠃⠀⢿⡇⠀⠀⡟⠉⢻⣿⣷⡄⠀⠈⢿⡇⠀⠀⠙⢿⣧⣤⡿⠛⠋⠉⠙⣿⣿⣿⣿⣿⣿⠇⠀⠈⠻⣿⣷⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠃⠀⠀⠀⠀⠀⠀⢻⣷⠀⠀⠀⠀⢸⣿⡀⠀⢿⣤⣼⣿⣿⡇⠀⠀⢸⡇⠀⢀⣤⣾⣿⠋⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⢹⣿⡇⢠
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⣿⣆⠀⠀⠀⠀⢻⣷⡀⠈⠻⠿⠿⠟⠀⠀⠀⣼⣡⣾⠟⠛⣿⣷⣀⢀⣠⣴⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⣼⣿⠁⣼
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⠀⠀⠀⠀⢀⣹⣿⣤⣤⣄⣀⡀⠀⠀⢸⣿⠟⠁⠀⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⣴⣿⠃⠀⣿
⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠰⠟⠛⠛⠋⠉⠉⠉⠉⠉⢡⡾⠃⠀⠀⠀⠀⠀⠉⠉⠉⠀⠀⠈⣿⣿⡿⠋⠀⠀⠀⠀⣠⣾⡿⠁⠀⢠⣿
⠀⠀⠀⠀⠀⠀⠀⠀⣸⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⢀⣴⡿⠋⠀⠀⠀⢸⣿
⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⢀⣠⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡿⠋⠀⠀⠀⠀⠀⣾⡇
⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⢀⣴⡾⢿⣿⣛⠛⠉⠉⠁⠀⠀⠀⠀⠀⠉⠁⠀⠰⣶⣶⠆⠀⠀⠀⠀⠀⣀⡴⣿⡏⠀⠀⠀⠀⠀⠀⣸⣿⠁
⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡀⠞⠉⠀⠀⠻⣿⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⠞⢉⣸⡟⠀⠀⠀⠀⠀⠀⢠⣿⡇⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⠀⠈⠙⠿⢿⣶⣦⣤⣀⣀⣀⣀⣀⣀⣀⣀⣠⣴⠶⠟⠋⠁⢠⣾⠏⠀⠀⠀⠀⠀⠀⢀⣾⡟⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣶⣦⣄⡀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠀⠀⠀⣠⣶⡿⠃⣾⡀⠀⠀⠀⠀⢀⣾⣿⠁⠀⠀
⠀⠀ ⠀⠀⠀⠀⠀⠀⠈⢿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠉⠙⠻⠿⣷⣶⣦⣤⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣶⣿⠟⠁⠀⠀⢿⣧⡀⠀⠀⣠⣿⡿⠁⠀⠀⠀
⠀⠀⠀   ⠀⠀⠀⠀⠈⢿⣿⣆⡀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠈⠉⠙⣿⣿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⣿⡟⠙⣿⠀⠀⠀⠀⠘⣿⣷⣶⣶⣿⠟⠁⠀⠀⠀⠀
      ⠀⠀⠀⠀⠀⠈⢿⣿⣷⡄⠀⠀⠀⠀⠀⣸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
      ⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣦⡀⠀⠀⢀⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠈⠻⢿⣿⣶⣤⣾⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
         ⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠛⠛⠁⠀⠀⠀");

            Console.ReadKey();
            Console.Clear();

            // Open Dash 
            UserSelection();
        }

        public static void UserSelection()
        {


            Console.WriteLine("Welcome to Paws and Claws\n ");
            Console.WriteLine("");
            Console.WriteLine("Please select one of the following options:\n ");
            Console.WriteLine("Enter 1 to : Set up your account\n");
            Console.WriteLine("Enter 2 to : Go to your Dashboard\n");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                Console.Clear();
                AccountCreation.UserSetup();

            }
            else if (userChoice == 2)
            {
                DashBoard.DashboardPage();

            }
            else
            {
                //Return to menu
                string message3 = "Invalid entry please try again";
                Console.WriteLine(message3);
                UserSelection();
            }
        }
    }


    class AccountCreation
    {


        public static void UserSetup()
        {
            // Welcome message
            Console.WriteLine("Welcome to your Account setup.\n");
            Console.WriteLine("");

            Console.WriteLine("Please create a username: \n");
            Program.UserName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome: " + Program.UserName + "\n");
            Console.WriteLine("");
            Console.WriteLine("Enter to comfirm Username: ");
            Console.WriteLine("");
            Console.WriteLine("Backspace to change.\n ");

            Console.WriteLine("Escape to return to main menu.\n");
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                OnePet.OnePetProfile();
            }
            else if (keyInfo.Key == ConsoleKey.Delete)
            {
                UserSetup();
            }
            else
            {
                StartConsole.UserSelection();
            }

        }


    }

    class OnePet
    {


        public static void OnePetProfile()
        {
            Console.Clear();
            Console.WriteLine("Please enter the type of pet you have: \n");
            Program.petType = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Please enter your Pets Name: \n");
            Program.petName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please enter " + Program.petName + " Breed\n");
            Program.petBreed = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Please enter " + Program.petName + " Gender \n");
            //  Need to oly allowing M / F
            Program.petGender = Console.ReadLine();
            Console.WriteLine("");

            // Print out  pet information for confirmation 
            Console.WriteLine("Your  pet is a: " + Program.petType);
            Console.WriteLine("\nPet Name: " + Program.petName);
            Console.WriteLine("\nPet Breed: " + Program.petBreed);
            Console.WriteLine("\nPet Gender: " + Program.petGender);
            Console.WriteLine("");

            Console.WriteLine("Enter to confirm: ");
            Console.WriteLine("\nBackspace to change: ");



            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                DashBoard.DashboardPage();
            }
            else
            {
                OnePetProfile();
            }
        }


    }
    class DashBoard
    {
        public static void DashboardPage()
        {
            Console.WriteLine("Welcome to your Dashboard" + Program.UserName);
            Console.WriteLine("\n Press enter to continue\n");

            Console.ReadKey();
            Console.Clear();

            DashboardSelection();
        }
        public static void DashboardSelection()
        {
            Console.WriteLine("Select which option you would like to view:\n");
            Console.WriteLine("1. For Pet Nutrition ");
            Console.WriteLine("2. For Health records");


            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                Console.Clear();
                NutritionDashboard.NutritionCreation();
            }
            else if (userChoice == 2)
            {
                Console.Clear();
                // RecordCreation.PetHealthRecords();
            }
            else
            {
                //return to menu
                string message4 = "Invalid entry please try again.";
                Console.WriteLine(message4);
                    Console.Clear();
                DashboardSelection();
            }



        }
    }
    class NutritionDashboard
    {
        public static void NutritionCreation()
        {
            //welcome message
            Console.WriteLine("\nHere you can find all your Pet Nutrition for" + Program.petName);
            Console.WriteLine("1. To view recommanded pet's food.\n");
            Console.WriteLine("2. To view current Food Recall History\n");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                Console.Clear();
                PetNutrition();

            }
            else if (userChoice == 2)
            {
                Console.Clear();

            }
            else
            {
                //return to menu
                string message3 = "Invalid entry please try again.";
                Console.WriteLine(message3);
                    Console.Clear();
                NutritionCreation();
            }
        }

        public static void PetNutrition()
        {
            Console.WriteLine("\nBelow you will find this Months list of Pet food for: " + Program.petName);


            var petConvert = Program.petType;

            var petNutri = petConvert.ToUpper();

            if (petNutri == "DOG")
            {
                DogNutrition.FoodProducts();
            }
            else if (petNutri == "CAT")
            {
                CatNutrition.FoodProducts();
            }
            else
            {
                DashBoard.DashboardSelection();
            }
        }




    }

    class DogNutrition
    {
        public static void FoodProducts()
        {
            Console.WriteLine("Dog Food: \n");

            Console.WriteLine("1. Wellness\n");
            Console.WriteLine("2. Hill Science Diet \n");
            Console.WriteLine("Select your perferd product for a list of ingredients");
            int userSelection = Convert.ToInt32(Console.ReadLine());
            if (userSelection == 1)
            {
                    Console.Clear();
                Console.WriteLine("Wellness\n");
                Console.WriteLine("Complete Health Large Breed\n");

                Console.WriteLine("List of Ingredients\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deboned Chicken\r\nChicken Meal\r\nPeas\r\nGround Brown Rice\r\nSalmon Meal\r\nOatmeal\r\nBarley\r\nOats\r\nTomato Pomace\r\nChicken Fat (preserved with Mixed Tocopherols)\r\nGround Flaxseed\r\nTomatoes\r\nSalmon Oil\r\nCarrots\r\nNatural Chicken Flavor\r\nSalt\r\nCholine Chloride\r\nSpinach\r\nVitamin E Supplement\r\nChicory Root Extract\r\nYucca Shidigera Extract\r\nTaurine\r\nZinc Proteinate\r\nMixed Tocopherols added to preserve freshness\r\nSweet Potatoes\r\nApples\r\nBlueberries\r\nZinc Sulfate\r\nCalcium Carbonate\r\nNiacin\r\nFerrous Sulfate\r\nIron Proteinate\r\nVitamin A Supplement\r\nAscorbic Acid (Vitamin C)\r\nCopper Sulfate\r\nThiamine Mononitrate\r\nCopper Proteinate\r\nManganese Proteinate\r\nManganese Sulfate\r\nd-Calcium Pantothenate\r\nSodium Selenite\r\nPyridoxine Hydrochloride\r\nRiboflavin\r\nGarlic Powder\r\nVitamin D3 Supplement\r\nBiotin\r\nCalcium Iodate\r\nVitamin B12 Supplement\r\nFolic Acid\r\nDried Lactobacillus plantarum Fermentation Product\r\nDried Enterococcus faecium Fermentation Product\r\nDried Lactobacillus casei Fermentation Product\r\nDried Lactobacillus acidophilus Fermentation Product\r\nRosemary Extract\r\nGreen Tea Extract\r\nSpearmint Extract.");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("\n1. Visit Wellness Homepage");
                Console.WriteLine("\n2. Return to DashBoard Menu");
                int userSelction = Convert.ToInt32(Console.ReadLine());
                if (userSelction == 1)
                {
                    System.Diagnostics.Process.Start("https://www.wellnesspetfood.com");
                }
                else
                {
                        Console.Clear();
                        DashBoard.DashboardSelection();
                }

            }
            else if (userSelection == 2)
            {
                Console.WriteLine("Hill Science Diet\n");
                Console.WriteLine("Adult Chicken & Barley Recipe Dog Food\n");

                Console.WriteLine("List of Ingredients\n");
                Console.WriteLine("Chicken\nCracked Pearled Barley\nWhole Grain Wheat\nWhole Grain Corn\nWhole Grain Sorghum\nCorn Gluten Meal\nSoybean Meal\nChicken Fat\nBrewers Rice\nChicken Liver Flavor\nChicken Meal\nDried Beet Pulp\nSoybean Oil\nPork Flavor\nLactic Acid\nCalcium Carbonate\nFlaxseed\nPotassium Chloride\nCholine Chloride\nIodized Salt\nvitamins (Vitamin E Supplement\nL-Ascorbyl-2-Polyphosphate (source of Vitamin C)\nNiacin Supplement\nThiamine Mononitrate\nVitamin A Supplement\nCalcium Pantothenate\nRiboflavin Supplement\nBiotin\nVitamin B12 Supplement\nPyridoxine Hydrochloride\nFolic Acid\nVitamin D3 Supplement)\nTaurine\nminerals (Ferrous Sulfate\nZinc Oxide\nCopper Sulfate\nManganous Oxide\nCalcium Iodate\nSodium Selenite)\nOat Fiber\nMixed Tocopherols for freshness\nNatural Flavors\nBeta-Carotene\nApples\nBroccoli\nCarrots\nCranberries\nGreen Peas.");

                int userSelction = Convert.ToInt32(Console.ReadLine());
                if (userSelction == 1)
                {
                    System.Diagnostics.Process.Start("https://www.hillspet.com");
                }
                else
                {
                        Console.Clear();
                        DashBoard.DashboardSelection();
                }


            }
            else
            {
                    Console.Clear();
                    DashBoard.DashboardSelection();
            }



        }
    }

    class CatNutrition
    {
        public static void FoodProducts()
        {
            Console.WriteLine("Cat Food: \n");

            Console.WriteLine("1. .......");
            Console.WriteLine("");
            Console.WriteLine("2. .........t \n");
            Console.WriteLine("Select your perferd product for a list of ingredients");
            int userSelection = Convert.ToInt32(Console.ReadLine());
            //  switch (userSelection)
            {
                //    case 1:
                // Console.WriteLine("Wellness");
                //   Console.WriteLine("Complete Health Large Breed\n");

                //  Console.WriteLine("List of Ingredients");

                //   Console.WriteLine("Deboned Chicken\r\nChicken Meal\r\nPeas\r\nGround Brown Rice\r\nSalmon Meal\r\nOatmeal\r\nBarley\r\nOats\r\nTomato Pomace\r\nChicken Fat (preserved with Mixed Tocopherols)\r\nGround Flaxseed\r\nTomatoes\r\nSalmon Oil\r\nCarrots\r\nNatural Chicken Flavor\r\nSalt\r\nCholine Chloride\r\nSpinach\r\nVitamin E Supplement\r\nChicory Root Extract\r\nYucca Shidigera Extract\r\nTaurine\r\nZinc Proteinate\r\nMixed Tocopherols added to preserve freshness\r\nSweet Potatoes\r\nApples\r\nBlueberries\r\nZinc Sulfate\r\nCalcium Carbonate\r\nNiacin\r\nFerrous Sulfate\r\nIron Proteinate\r\nVitamin A Supplement\r\nAscorbic Acid (Vitamin C)\r\nCopper Sulfate\r\nThiamine Mononitrate\r\nCopper Proteinate\r\nManganese Proteinate\r\nManganese Sulfate\r\nd-Calcium Pantothenate\r\nSodium Selenite\r\nPyridoxine Hydrochloride\r\nRiboflavin\r\nGarlic Powder\r\nVitamin D3 Supplement\r\nBiotin\r\nCalcium Iodate\r\nVitamin B12 Supplement\r\nFolic Acid\r\nDried Lactobacillus plantarum Fermentation Product\r\nDried Enterococcus faecium Fermentation Product\r\nDried Lactobacillus casei Fermentation Product\r\nDried Lactobacillus acidophilus Fermentation Product\r\nRosemary Extract\r\nGreen Tea Extract\r\nSpearmint Extract.");


            }




        }
    }




   
}



                                                                                         