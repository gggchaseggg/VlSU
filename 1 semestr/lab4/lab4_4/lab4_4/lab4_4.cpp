#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
int n = 10, a[12], b = rand() % 101 - 50, mn = 51, ind;
int main() {
    srand(time(NULL));
    cout << "Array: ";
    for (int i = 0; i < n; i++) {
        a[i] = rand() % 101 - 50;
        if ((a[i] >= 0) and (a[i] < mn)) {
            mn = a[i];
            ind = i;
        }
        cout << a[i] << " ";
    }
    a[10] = 0; a[11] = 0;
    for (int i = 0; i < n - ind + 1; i++) {
        if (n - i == ind) {
            a[n + 1 - i] = a[n - 1];
        }
        else {
            a[(n + 1) - i] = a[n - i - 1];
        }
        cout << a[i] << " ";
    }
    a[ind] = b; a[ind + 2] = b;
    cout << a[10] << " " << a[11];
    cout << "\nNuber b:" << b;
    return 0;
}