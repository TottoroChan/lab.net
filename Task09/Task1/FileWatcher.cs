using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	public class FileWatcher
	{
		FileSystemWatcher TextWatcher;
		string targetPath = @"temp" ; //папка создается в дебаге

		public FileWatcher(string path)
		{
			TextWatcher = new FileSystemWatcher();
			TextWatcher.Path = path;
		}

		/// <summary>
		///  режим наблюдения
		/// </summary>
		public void Watching()
		{			
			if (!Directory.Exists(targetPath))
			{
				Directory.CreateDirectory(targetPath);
			}

			TextWatcher.Filter = "*.txt";
			TextWatcher.IncludeSubdirectories = true;
			TextWatcher.NotifyFilter = NotifyFilters.LastWrite;
			TextWatcher.NotifyFilter =
			   NotifyFilters.LastWrite | NotifyFilters.Size;
			TextWatcher.Changed += new FileSystemEventHandler
								(OnChanged);
			TextWatcher.Created += new FileSystemEventHandler
								(OnChanged);
			TextWatcher.Deleted += new FileSystemEventHandler
								(OnChanged);
			TextWatcher.EnableRaisingEvents = true;
			Console.WriteLine(">>>Нажмите \'0\' чтобы завершить наблюдение.");
			while (Console.Read() != '0') ;
			TextWatcher.EnableRaisingEvents = false;
		}

		/// <summary>
		///  режим отката
		/// </summary>
		public void Recovery()
		{
			DirectoryInfo dir = new DirectoryInfo(targetPath);
			FileInfo[] txtfiles = dir.GetFiles("*.txt");
			Console.WriteLine("Название\tДата создания");
			foreach (FileInfo f in txtfiles)
			{
				Console.WriteLine("{0}\t{1}", f.Name, f.LastWriteTime);

			}
			Console.WriteLine(">>>Введите дату в формате дд.мм.гггг чч:мм:сс");
			DateTime time = Convert.ToDateTime(Console.ReadLine());
			//сортировка изменений файлов по времени.
			for (int i = 0; i < txtfiles.Length; i++) 
				for (int j = i + 1; j<txtfiles.Length; j++)
				{
					if(txtfiles[i].LastWriteTime > txtfiles[j].LastWriteTime)
					{
						FileInfo temp = txtfiles[i];
						txtfiles[i] = txtfiles[j];
						txtfiles[j] = temp;
                    }
				}
			foreach (FileInfo f in txtfiles)
			{
				if (f.CreationTime <= time)
				{
					string name = "";
					string sourceFile = Path.Combine(targetPath, f.Name);
					for (int i = 0; i < f.Name.Length - 13; i++)
					{
						name = name + f.Name[i];
					}
					name = name + ".txt";
					string destFile = Path.Combine(TextWatcher.Path, name);
					File.Copy(sourceFile, destFile, true);
				}
				
			}
			Console.WriteLine(">>>Файлы восстановлены.");
		}

		public void OnChanged(object sender, FileSystemEventArgs e)
		{
			string  name = "";
			string sourceFile = Path.Combine(TextWatcher.Path, e.Name);
			for (int i=0; i<e.Name.Length - 4; i++)
			{
				name = name + e.Name[i];
			}
			name = name + "-" + DateTime.Now.ToString("HH-mm-ss") + ".txt";
            string destFile = Path.Combine(targetPath, name);
			Console.WriteLine(">>>Файл {0} был изменён", e.Name);
			File.Copy(sourceFile, destFile, true);
		}
	}
}
