using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Group_Dealer
{
    public class Dealer
    {
        private Random random = new Random();
        public void GetParameters(string students, string subjects, int number)
        {

            //My variables
            int members = 0;
            int topics = 0;
            int studentsPerGroup = 0;
            int remainingStudents = 0;
            int subjectsPerGroup = 0;
            int remainingSubjects = 0;
            string[,] group;
            string[,] subjectsGroup;
            //We get and shuffle the list of students from the file.
            List<string> Students = File.ReadLines(students).ToList();
            List<string> Subjects = File.ReadLines(subjects).ToList();
            List<string> models = Students.OrderBy(c => random.Next()).Select(c => c).ToList();
            List<string> subs = Subjects.OrderBy(f => random.Next()).Select(f => f).ToList();
            //Getting the number of students.
            foreach (string line in File.ReadLines(students))
            {
                members++;
            }
            //Getting the number of subjects.
            foreach (string line in File.ReadLines(subjects))
            {
                topics++;
            }
            //Calculating students by group and others
            studentsPerGroup = members / number;
            remainingStudents = members % number;
            subjectsPerGroup = topics / number;
            remainingSubjects = topics % number;

            group = new string[number, studentsPerGroup + 1];
            subjectsGroup = new string[number, subjectsPerGroup + 1];
            Console.WriteLine("");
            //Dealing the students by group
            for (int i = 0; i < number; i++){
                for (int j = 0; j < studentsPerGroup; j++) {
                    group[i, j] = models[0].ToString();
                    models.RemoveAt(0);
                }
            }
            //Dealing the subjects by group
            for (int i = 0; i < number; i++){
                for (int j = 0; j < subjectsPerGroup; j++) {
                    subjectsGroup[i, j] = subs[0].ToString();
                    subs.RemoveAt(0);
                }
            }
            //In case that students module != 0
            if(models.Count % number != 0){
                while(remainingStudents != 0){
                    int index = random.Next(0, number);
                    if(group[index, studentsPerGroup] != null){
                        group[index, studentsPerGroup] = group[index, studentsPerGroup];
                    } else{
                        group[index, studentsPerGroup] = models[0];
                        models.RemoveAt(0);
                        remainingStudents--;
                    }   
                }
            } 
            //In case that topics moddule != 0
            if(subs.Count % number != 0){  
                while(remainingSubjects != 0){
                    int index = random.Next(0, number);
                    if(subjectsGroup[index, subjectsPerGroup] != null){
                        subjectsGroup[index, subjectsPerGroup] = subjectsGroup[index, subjectsPerGroup];
                    }else{
                        subjectsGroup[index, subjectsPerGroup] = subs[0];
                        subs.RemoveAt(0);
                        remainingSubjects--;
                    } 
                }
            }

            //Display of groups and topics
              for (int i = 0; i < number; i++){
              int k=0;
              int z=0;
              int count = 0;
              int sCount = 0;
              while(group[i, k] != "" && group[i, k] != null){
                  count++;
                  k++;
                  if(k >= studentsPerGroup + 1){
                      break;
                  }
              }
               while(subjectsGroup[i, z] != "" && subjectsGroup[i, z] != null){
                  sCount++;
                  z++;
                  if(z >= subjectsPerGroup + 1){
                      break;
                  }
              }
                Console.WriteLine($"Grupo {i + 1} (Estudiantes: {count}, Temas: {sCount})");       
                Console.WriteLine("                Estudiantes:");   
                for (int j = 0; j < count; j++){
                Console.WriteLine("                         " + group[i, j]); }
                Console.WriteLine("");
                Console.WriteLine("                Temas:");   
                for (int j = 0; j < sCount; j++){
                Console.WriteLine("                         " + subjectsGroup[i, j]); }
                Console.WriteLine("");
            }
        }
    }
}
