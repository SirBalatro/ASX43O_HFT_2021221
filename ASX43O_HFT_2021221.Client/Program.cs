using ASX43O_HFT_2021221.Models;
using ConsoleTools;
using System;
using System.Linq;

namespace ASX43O_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RestService restService = new RestService("http://localhost:8797");

            ConsoleMenu consoleMenu = new ConsoleMenu();
            ConsoleMenu createMenu = new ConsoleMenu();
            ConsoleMenu readMenu = new ConsoleMenu();
            ConsoleMenu updateMenu = new ConsoleMenu();
            ConsoleMenu deleteMenu = new ConsoleMenu();
            ConsoleMenu noncrudMenu = new ConsoleMenu();



            //Read
            readMenu.Add("List all characters",() =>
            {
                Console.Clear();
                var res = restService.Get<PlayerCharacter>("/PlayerCharacter");

                foreach (PlayerCharacter item in res)
                {
                    Console.WriteLine("Id: " + item.Id + " Name: " + item.Name + " Race: " + item.Race?.Name ?? "none");
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            readMenu.Add("List all races", () =>
            {
                Console.Clear();
                var res = restService.Get<PlayerCharacter>("/PlayerRace");

                foreach (PlayerCharacter item in res)
                {
                    Console.WriteLine("Id: " + item.Id + " Name: " + item.Name);
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            readMenu.Add("List all classes", () =>
            {
                Console.Clear();
                var res = restService.Get<PlayerCharacter>("/PlayerClass");

                foreach (PlayerCharacter item in res)
                {
                    Console.WriteLine("Id: " + item.Id + " Name: " + item.Name);
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            readMenu.Add("List all items", () =>
            {
                Console.Clear();
                var res = restService.Get<PlayerCharacter>("/PlayerItem");

                foreach (PlayerCharacter item in res)
                {
                    Console.WriteLine("Id: " + item.Id + " Name: " + item.Name);
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            readMenu.Add("Back to Main Menu", () =>
            {
                readMenu.CloseMenu();
            });

            //Create
            createMenu.Add("Add a character", () =>
            {
                Console.Clear();
                var c = new PlayerCharacter();
                Console.WriteLine("Enter character name (required):");
                c.Name = Console.ReadLine();
                Console.WriteLine("Enter race id (required):");
                c.RaceId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter class id (required):");
                c.ClassId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter character level (optional):");
                var input = Console.ReadLine();
                if (input != "")
                {
                    c.CharacterLevel = int.Parse(input);
                }

                restService.Post<PlayerCharacter>(c, "/PlayerCharacter");


                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            createMenu.Add("Add a race", () =>
            {
                Console.Clear();

                var c = new PlayerRace();
                Console.WriteLine("Enter race name (required):");
                c.Name = Console.ReadLine();

                restService.Post<PlayerRace>(c, "/PlayerRace");



                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            createMenu.Add("Add a class", () =>
            {
                Console.Clear();

                var c = new PlayerClass();
                Console.WriteLine("Enter class name (required):");
                c.Name = Console.ReadLine();

                restService.Post<PlayerClass>(c, "/PlayerClass");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            createMenu.Add("Add an item", () =>
            {
                Console.Clear();

                var c = new PlayerItem();
                Console.WriteLine("Enter item name (required):");
                c.Name = Console.ReadLine();
                Console.WriteLine("Enter owners id (required):");
                c.OwnerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter required level (optional):");
                var input = Console.ReadLine();
                if (input != "")
                {
                    c.ReqLevel = int.Parse(input);
                }

                restService.Post<PlayerItem>(c, "/PlayerItem");


                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            createMenu.Add("Back to Main Menu", () =>
            {
                createMenu.CloseMenu();
            });

            //Update
            updateMenu.Add("Update a character", () =>
            {
                Console.Clear();

                var c = new PlayerCharacter();
                Console.WriteLine("Enter character id (required):");
                c.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter character name (required):");
                c.Name = Console.ReadLine();
                Console.WriteLine("Enter race id (required):");
                c.RaceId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter class id (required):");
                c.ClassId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter character level (optional):");
                var input = Console.ReadLine();
                if (input != "")
                {
                    c.CharacterLevel = int.Parse(input);
                }

                restService.Put<PlayerCharacter>(c, "/PlayerCharacter");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            updateMenu.Add("Update a race", () =>
            {
                Console.Clear();

                var c = new PlayerRace();
                Console.WriteLine("Enter race id (required):");
                c.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter race name (required):");
                c.Name = Console.ReadLine();

                restService.Put<PlayerRace>(c, "/PlayerRace");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            updateMenu.Add("Update a class", () =>
            {
                Console.Clear();

                var c = new PlayerClass();
                Console.WriteLine("Enter class id (required):");
                c.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter class name (required):");
                c.Name = Console.ReadLine();

                restService.Put<PlayerClass>(c, "/PlayerClass");


                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            updateMenu.Add("Update an item", () =>
            {
                Console.Clear();

                var c = new PlayerItem();
                Console.WriteLine("Enter item id (required):");
                c.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter item name (required):");
                c.Name = Console.ReadLine();
                Console.WriteLine("Enter owners id (required):");
                c.OwnerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter required level (optional):");
                var input = Console.ReadLine();
                if (input != "")
                {
                    c.ReqLevel = int.Parse(input);
                }

                restService.Put<PlayerItem>(c, "/PlayerItem");


                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            updateMenu.Add("Back to Main Menu", () =>
            {
                updateMenu.CloseMenu();
            });

            //Delete
            deleteMenu.Add("Delete a character", () =>
            {
                Console.Clear();

                Console.WriteLine("Enter character id (required):");
                var c = int.Parse(Console.ReadLine());

                restService.Delete(c, "/PlayerCharacter");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            deleteMenu.Add("Delete a race", () =>
            {
                Console.Clear();

                Console.WriteLine("Enter race id (required):");
                var c = int.Parse(Console.ReadLine());

                restService.Delete(c, "/PlayerRace");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            deleteMenu.Add("Delete a class", () =>
            {
                Console.Clear();

                Console.WriteLine("Enter class id (required):");
                var c = int.Parse(Console.ReadLine());

                restService.Delete(c, "/PlayerClass");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            deleteMenu.Add("Delete an item", () =>
            {
                Console.Clear();

                Console.WriteLine("Enter item id (required):");
                var c = int.Parse(Console.ReadLine());

                restService.Delete(c, "/PlayerItem");

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            deleteMenu.Add("Back to Main Menu", () =>
            {
                deleteMenu.CloseMenu();
            });

            //Non-Crud
            noncrudMenu.Add("Get character with best item", () =>
            {
                Console.Clear();

                var res = restService.GetSingle<PlayerCharacter>("/Stat/CharacterWithBestItem");
                Console.WriteLine("Owner of the best item: " + res.Name);

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            noncrudMenu.Add("Get character with selected item", () =>
            {
                Console.Clear();

                Console.WriteLine("Enter item id (required):");
                var itemid = int.Parse(Console.ReadLine());
                var res = restService.Get<PlayerCharacter>(itemid, "/Stat/CharacterWithItem");
                Console.WriteLine("Owner of the item:" + res.Name);

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            noncrudMenu.Add("Items used by a selected class", () =>
            {
                Console.Clear();

                Console.WriteLine("Enter class id (required):");
                var classid = int.Parse(Console.ReadLine());
                var res = restService.GetListWithArgument<PlayerItem>(classid, "/Stat/ItemsUsedByClass");

                if (!res.Count().Equals(0))
                {
                    foreach (var item in res)
                    {
                        Console.WriteLine("Name: " + item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("No items are used by this class");
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            noncrudMenu.Add("List used classes", () =>
            {
                Console.Clear();

                var res = restService.Get<PlayerClass>("/Stat/UsedClasses");
                if (!res.Count().Equals(0))
                {
                    foreach (var item in res)
                    {
                        Console.WriteLine("Name: " + item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("There are no classes or none of them are used");
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            noncrudMenu.Add("Items grouped by races", () =>
            {
                Console.Clear();

                var results = restService.Get<ItemsByRaceResult>("/Stat/ItemsByRace");

                if (!results.Count().Equals(0))
                {
                    foreach (var result in results)
                    {
                        Console.Write("Race: " + result.Race.Name + " ");
                        Console.Write(string.Join(", ", result.Items.Select(x => x.Name)));
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("There are no races, or characters");
                }



                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            });

            noncrudMenu.Add("Back to Main Menu", () =>
            {
                noncrudMenu.CloseMenu();
            });


            //MainMenu
            consoleMenu.Add("Create", () =>
            {
                createMenu.Show();
            });
            consoleMenu.Add("Read", () =>
            {
                readMenu.Show();
            });
            consoleMenu.Add("Update", () =>
            {
                updateMenu.Show();
            });
            consoleMenu.Add("Delete", () =>
            {
                deleteMenu.Show();
            });
            consoleMenu.Add("Non-crud", () =>
            {
                noncrudMenu.Show();
            });
            consoleMenu.Add("Exit", () =>
            {
                consoleMenu.CloseMenu();
            });

            consoleMenu.Show();
        }
    }
}
