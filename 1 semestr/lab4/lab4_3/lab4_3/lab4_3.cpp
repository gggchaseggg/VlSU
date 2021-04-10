#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
int y[25], z[5], s = 0;
int main() {
    srand(time(NULL));
    cout << "Array y: ";
    for (int i = 0; i < 25; i++) {
        y[i] = rand() % 101 - 50;
        cout << y[i] << " ";
    }
    cout << "\nArray z: ";
    for (int i = 0; i < 5; i++) {
        for (int j = 0; j < 5; j++) {
            s = s + y[i * 5 + j];
        }
        z[i] = s;
        cout << z[i] << " ";
     }
    return 0;
}
