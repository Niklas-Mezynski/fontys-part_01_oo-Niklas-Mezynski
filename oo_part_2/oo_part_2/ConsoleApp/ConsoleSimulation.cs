using oo_part_2.Persistence;

namespace oo_part_1.Entities;

public class ConsoleSimulation
{
    private IUserPersistence _persistence;
    private CreateUserProcedure _createUserProcedure;
    private UsersOverviewProcedure _usersOverviewProcedure;
    private UserDetailProcedure _userDetailProcedure;
    
    public ConsoleSimulation(IDbFactory factory)
    {
        _persistence = factory.CreateUserPersistence();
        _createUserProcedure = new CreateUserProcedure(_persistence);
        _usersOverviewProcedure = new UsersOverviewProcedure(_persistence);
        _userDetailProcedure = new UserDetailProcedure(_persistence);
    }

        public void StartSimulation()
        {
            while (true)
            {
                Console.WriteLine("\nWhich action do you want to perform? Enter the number please\n" +
                                  "1. Create user\n" +
                                  "2. Show overview users in database\n" +
                                  "3. Show user details\n" +
                                  "4. Exit application\n");
                int action = Helpers.ReadIntFromConsole();
                Console.Clear();

                switch (action)
                {
                    case 1:
                        _createUserProcedure.startProcedure();
                        break;
                    case 2:
                        _usersOverviewProcedure.startProcedure();
                        break;
                    case 3:
                        _userDetailProcedure.StartProcedure();
                        break;
                    case 4:
                        action = 0;
                        break;
                }
                
                if (action == 0)
                {
                    break;
                }

                Console.Out.Write("-----------------Press enter to continue-----------------");
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("End of program");
        }
}