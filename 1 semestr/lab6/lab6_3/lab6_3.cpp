#include <iostream>
#include <cmath>
#include <ctime>
#include <cstdlib>
using namespace std;

int** zapolnenie(int count_row, int count_columns) {

	srand(time(NULL));

	int** matrix = new int* [count_row];
	for (int i = 0; i < count_columns; i++) {
		matrix[i] = new int[count_columns];
	}

	for (int row = 0; row < count_row; row++) {
		for (int columns = 0; columns < count_columns; columns++) {
			matrix[row][columns] = rand() % 101 - 50;
			cout << matrix[row][columns] << '\t';
		}
		cout << endl;
	}
	return matrix;
}

int max_stroka(int** matrix) {
	int max_v_str = 0, index_max_str;
	for (int row = 0; row < sizeof(matrix); row++) {
		int proizvedenie = 1;
		for (int columns = 0; columns < sizeof(matrix[0]); columns++) {
			if (matrix[row][columns] < 0) {
				proizvedenie = proizvedenie * matrix[row][columns];
			}
		}
		if (abs(proizvedenie) > max_v_str) {
			max_v_str = abs(proizvedenie);
			index_max_str = row;
		}
	}
	return index_max_str;
}

int main() {
	
	int count_row, count_columns, index;
	int** matrix;

	cout << "Number of lines: ";
	cin >> count_row;
	cout << "Number of columns: ";
	cin >> count_columns;
	cout << endl;

	matrix = zapolnenie(count_row, count_columns);
	index = max_stroka(matrix);

	cout << "Index: " << index;

}

