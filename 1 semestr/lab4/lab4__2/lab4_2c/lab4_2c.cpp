#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
int n = 10, a[10], b[10], c[10], s;
int main() {
    srand(time(NULL));
    cout << "Array: ";
    for (int i = 0; i < n; i++) {
        a[i] = rand() % 101 - 50;
        b[i] = rand() % 101 - 50;
        c[i] = a[i] + b[i];
        cout << c[i] << " ";
        if (c[i] >= 0) {
            s = s + c[i];
        }
    }
    cout << "\nSum:" << s;
    return 0;
}