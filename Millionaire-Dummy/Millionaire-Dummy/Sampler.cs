/********************************************************************************************************************
* Team Members : Ravishka Rathnasuriya & Sabin Dheke
* Professor    : Dr. Catherine Stringfellow  
* Class        : CMPS 4143
* Assignment   : Assignment 4- Who wants to be the millionaire 
* Date         : 09/28/2020
* Description  :
  The assignment is a team work that has to design the game Who wants to be the millionaire.    
  The game is consited of 15 rounds with 4 lifelines options, 50-50, Ask the audience, phone a friend, and walk away.
  The game also consist of 3 safe havens. complete level 5 to win $1,000. Complete level 10 to win $32,000. Complete level 15 to win $1 Million.
 *The game has used entire paths for directories of files. For example "C:/Users/shema/OneDrive/Desktop/CMPS-4143 C#/Assignment 4 Dummy/Resources/sound/start_game.wav"
 *If the user wants to change the file, he/she should change the path name and used it. 
 
  Two classes have been used. One for Questions and the other for Sampler. 
  Only public properties has been used. Eventhough it is not the best way to use the class properties, we had to deal with public properties.
  The game works according to the guidelines. The class descriptions has been commented near each method and classes.

   To work with Lists, we used: //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netcore-3.1
   and for stream reader- // //https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netcore-3.1 as a reference. 
 ********************************************************************************************************************/


using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Millionaire_Dummy
{
    /*************************************************************************************************************
     Class name :class Question
     Class type: public
    This class is for questions. 
    Class has attributes of string question, answer1, answer2,answer3, answer4, and key and
    bool used. All the attributes are public.
    The class contains only a parametrized default constructor.
    **************************************************************************************************************/
    class Question
    {
        public string question;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public string key;
        public bool used;

    /*************************************************************************************************************
    Function name: public Question(string q, string a1, string a2, string a3, string a4, string k, bool used)
    Return Type: No return type
    This is a parametrized default constructor. 
    This will store the default values for each attribute. 
    **************************************************************************************************************/
        public Question(string q, string a1, string a2, string a3, string a4, string k, bool used)
        {
            question = q;
            answer1 = a1;
            answer2 = a2;
            answer3 = a3;
            answer4 = a4;
            key = k;
            this.used = used;
        }
    }


    /*************************************************************************************************************
     Class name: Class Sampler
     Class Type: Public
    This call will make a list of questions using the Question class. 
    Also, it has a Cur_Question attribute that is using the Question class. 
    and another public attribute for level. 
    The class has several methods. That will implement the game. 
    Descriptions of each method is defined near the methods.
    **************************************************************************************************************/
    class Sampler
    {
        public List<Question> questions;
        public Question Cur_Question;
        public int level;

      /*************************************************************************************************************
       Method name: public Sampler()
       Return Type: No return type:
      This is a default constructor. It will initialize the level to 1, and list of questions to the size of 15
      It will also call the Storedata() function.
      **************************************************************************************************************/
        public Sampler()
        {
            questions = new List<Question>(15);
            level = 1;
            Storedata();
        }

        /*************************************************************************************************************
         Method name: public void Storedata()
         Return type: void
        This method is used to store the data for the list of questions. First it will read a file and then store
        each list including the question, 4 answrers, the key, and the use of question to false. 
        The function will prompt the user to select the input file and see if the input file is valid or not. 
        The it will start reading the file. The storing part is done using a do while loop that will iterate 15 times. 
        Also, an exception has been used if the file is not valid. Therefore, user will have to pick a valid file. 

        **************************************************************************************************************/
        public void Storedata()
        {
            //open a file dialog event from the properties. 
            FileDialog fileChooser = new OpenFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string filename;
            //check for result
            if(result != DialogResult.Cancel)
            {
                //store the filename
                filename = fileChooser.FileName;
                //if filename is invalid
                if (filename == "" || filename == null)
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if file is exitsts
                if (File.Exists(filename)) 
                {
                    try
                    {
                        //use the streamReader to read the file. 
                        using (StreamReader reader = new StreamReader(filename))
                        {
                            List<Question> dummy = new List<Question>(15);
                            int i = 0;
                            //do while loop  to store data
                            do
                            {
                                string q = reader.ReadLine();
                                string a1 = reader.ReadLine();
                                string a2 = reader.ReadLine();
                                string a3 = reader.ReadLine();
                                string a4 = reader.ReadLine();
                                string key = a1;
                                dummy.Add(new Question(q, a1, a2, a3, a4, key, false));
                                i++;

                            } while (i < 15);

                            reader.Close();
                            //assign it to questions list
                            questions = dummy;


                        }
                    }
                    //if file is not valid show it in a message box and start over
                    catch (Exception e)
                    {
                        MessageBox.Show("The file couldn't be read: ");
                        MessageBox.Show(e.Message);
                    }
                }
               
            }
           
        }

        /*****************************************************************************************************
        Method name: public int[] AskTheAudience()
        Return type: Array of integers
        This function is to store the amount of vote that the audience has been picked for each answer.
        Used the Random class to pick random numbers.
        And has been used the ? opetaor too. 
        It will store the votes for 4 answers in an array and returns the array. 
        *****************************************************************************************************/
        public int[] AskTheAudience()
        {
            int[] options = new int[4];
            Random randomNumbers = new Random();
            options[0] = randomNumbers.Next(0, 101);
            options[1] = randomNumbers.Next(0, 100 - options[0]);
            options[2] = randomNumbers.Next(0, 100 - options[0] - options[1]);
            int remainder = (100 - options[0] - options[1] - options[2]);
            options[3] = remainder > 0 ? remainder : 0;
           
            return options;
            
        }

        /*****************************************************************************************************
        Method name: public string[] Lifeline50_50()
        Return type: array of strings
        This function has used the Random class to pick two 2 answers except the the correct answer, and stores in the array
        Have been used if statements to compare correct answer with each answer and then store it to the array.
       *****************************************************************************************************/
        public string[] Lifeline50_50()
        {
            string[] options = new string[2];
            Random randomNumbers = new Random();
        //for answer A
            if (Cur_Question.key == Cur_Question.answer1)
            {
                options[0] = Cur_Question.answer2;
                int x = randomNumbers.Next(3, 5);
                if (x == 3)
                {
                    options[1] = Cur_Question.answer3;
                }
                else
                {
                    options[1] = Cur_Question.answer4;
                }
            }
            // for answer B
            if (Cur_Question.key == Cur_Question.answer2)
            {
                options[0] = Cur_Question.answer1;
                int x = randomNumbers.Next(3, 5);
                if (x == 3)
                {
                    options[1] = Cur_Question.answer3;
                }
                else
                {
                    options[1] = Cur_Question.answer4;
                }
            }
            //for Answer C
            if (Cur_Question.key == Cur_Question.answer3)
            {
                options[0] = Cur_Question.answer4;
                int x = randomNumbers.Next(1, 3);
                if (x == 1)
                {
                    options[1] = Cur_Question.answer1;
                }
                else
                {
                    options[1] = Cur_Question.answer2;
                }
            }
            // for Answer D
            if (Cur_Question.key == Cur_Question.answer4)
            {
                options[0] = Cur_Question.answer3;
                int x = randomNumbers.Next(1, 3);
                if (x == 1)
                {
                    options[1] = Cur_Question.answer1;
                }
                else
                {
                    options[1] = Cur_Question.answer2;
                }
            }

            return options;

        }


        /*****************************************************************************************************
        Method name: public in PhoneAFriend()
        return type: int
        This function is for phone a friend lifeline. It will return an integer using a random class. 
        1 for A, 2 for B, 3 for C, and 4 for D
       *****************************************************************************************************/
        public int PhoneAFriend()
        {
            Random randomNumbers = new Random();
            return randomNumbers.Next(1, 5);
        }


        /*****************************************************************************************************
         Method name: public Question CreateQandA()
        Return Type: question from a Question class.
        This function is used to organize the answers randomly. Has been used random class.
        It will check for questions if it has been used before or not.  if not, then then it will rearrange the answers.
        Then it will return the current questions  for the buttons and labels. 
        used if statments to each asnwer and then reorganize them. 
       *****************************************************************************************************/
        public Question CreateRanQandA()
        {
            
            Random randNumbers = new Random();
            int ans = randNumbers.Next(1, 5);
      
            string ans1, ans2, ans3, ans4;
            int id = level-1;
            //if game is not reached the the 16th level
            if (level < 16)
            {
                // if the questions has not been used 
                if (!questions[id].used)
                {
                    //store the current questions in a temp variables
                    Cur_Question = questions[id];
                    ans1 = Cur_Question.answer1;
                    ans2 = Cur_Question.answer2;
                    ans3 = Cur_Question.answer3;
                    ans4 = Cur_Question.answer4;
                    questions[id].used = true;

                    //if random value is 1
                    if (ans == 1)
                    {
                        Cur_Question.answer1 = ans1;
                        Cur_Question.answer2 = ans2;
                        Cur_Question.answer3 = ans3;
                        Cur_Question.answer4 = ans4;

                    }

                 //   if random value is 2
                    if (ans == 2)
                    {
                        Cur_Question.answer1 = ans2;
                        Cur_Question.answer2 = ans3;
                        Cur_Question.answer3 = ans4;
                        Cur_Question.answer4 = ans1;
                    }
                    //if randome value is 3
                    if (ans == 3)
                    {
                        Cur_Question.answer1 = ans3;
                        Cur_Question.answer2 = ans4;
                        Cur_Question.answer3 = ans1;
                        Cur_Question.answer4 = ans2;
                    }
                    //else if random value is 4
                    else
                    {
                        Cur_Question.answer1 = ans4;
                        Cur_Question.answer2 = ans1;
                        Cur_Question.answer3 = ans2;
                        Cur_Question.answer4 = ans3;
                    }

                }




                else if (level < 14)
                {
                    CreateRanQandA();
                }
            }
            
            return Cur_Question;

        }


    }
}
