#include "stdafx.h" 
#include <iostream> 
#include <vector> 
#include <string> 
#include <time.h> 

using namespace std;

class StrClass
{
	vector<string> strings;
	bool isCreated;
	int size;

	string GenerateString(int size)
	{
		string str;
		str.resize(size);

		for (int i = 0; i < size; i++)
		{
			str[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[rand() % 26];
		}

		return str;
	}

	string UniqueString(string str)
	{
		for (int i = 0; i < str.length(); i++)
		{
			for (int j = i + 1; j < str.length(); j++)
			{
				if (str[i] == str[j])
				{
					str.erase(j, 1);
				}
			}
		}

		return str;
	}

public:
	StrClass()
	{
		isCreated = false;
	}

	bool IsCreated()
	{
		return isCreated;
	}

	int GetSize()
	{
		return size;
	}

	void Insert(string str)
	{
		strings.insert(strings.end(), str);
		size++;
	}

	void Set(int elem, int size)
	{
		strings[elem] = GenerateString(size);
	}

	string Get(int id)
	{
		return strings[id];
	}

	string Join(int id1, int id2)
	{
		string str, str1, str2;

		str1 = Get(id1 - 1);
		str2 = Get(id2 - 1);

		str = str1 + str2;

		return str;
	}

	string JoinWithouRepeat(int id1, int id2)
	{
		string str;

		str = Join(id1, id2);
		str = UniqueString(str);

		return str;
	}

	void Create(int isize)
	{
		for (int i = 0; i < isize; i++)
		{
			int strSize;

			cout << "������� ������ ������ " << i + 1 << ": ";
			cin >> strSize;

			strings.insert(strings.end(), GenerateString(strSize));
			cout << strings[i] << endl;
		}

		size = isize;
		isCreated = true;
	}
};

int main()
{
	setlocale(LC_ALL, "");
	srand(time(NULL));

	int menuPointer = -1;

	StrClass * obj = new StrClass();

	while (menuPointer != 6)
	{
		cout << "1. ������� ������ �����" << endl;
		cout << "2. ������� ������ �� ������" << endl;
		cout << "3. ������� ���� ������" << endl;
		cout << "4. ���������� ��� ������" << endl;
		cout << "5. ���������� ��� ������ (��� �������)" << endl;
		cout << "6. �����" << endl;
		cout << "> ";

		cin >> menuPointer;

		system("cls");

		switch (menuPointer)
		{
		case 1:
		{
			if (!obj->IsCreated())
			{
				int size = 0;
				cout << "������� ��� �� �����: ";
				cin >> size;

				obj->Create(size);
			}
			else
			{
				cout << "������ ��� ������!" << endl;
			}

			system("pause");
			system("cls");
		}
		break;

		case 2:
		{
			if (obj->IsCreated())
			{
				int id = 0;
				cout << "������ �������: " << obj->GetSize() << endl;
				cout << "������� ����� ������: " << endl;
				cin >> id;

				if ((id > 0) && (id <= obj->GetSize()))
				{
					cout << "������ " << id << " = " << obj->Get(id - 1) << endl;
				}
				else
				{
					cout << "������ ������ �� ����������!" << endl;
				}
			}
			else
			{
				cout << "������ ��� �� ������!" << endl;
			}

			system("pause");
			system("cls");
		}
		break;

		case 3:
		{
			if (obj->IsCreated())
			{
				cout << "������ �������� " << obj->GetSize() << ": " << endl;

				for (int i = 0; i < obj->GetSize(); i++)
				{
					cout << "������ " << i + 1 << ": " << obj->Get(i) << endl;
				}
			}
			else
			{
				cout << "������ ��� �� ������!" << endl;
			}

			system("pause");
			system("cls");
		}
		break;

		case 4:
		{
			if (obj->IsCreated())
			{
				int first, second;

				cout << "������� ����� ������ ������: ";
				cin >> first;

				cout << "������� ����� ������ ������: ";
				cin >> second;

				if (((first > 0) && (first <= obj->GetSize())) && ((second > 0) && (second <= obj->GetSize())))
				{
					obj->Insert(obj->Join(first, second));
					cout << "���������� ������: " << obj->Get(obj->GetSize() - 1) << endl;
				}
				else
				{
					cout << "������ ����� �� ����������!" << endl;
				}
			}
			else
			{
				cout << "������ ��� �� ������!" << endl;
			}

			system("pause");
			system("cls");
		}
		break;

		case 5:
		{
			if (obj->IsCreated())
			{
				int first, second;

				cout << "������� ����� ������ �����";
