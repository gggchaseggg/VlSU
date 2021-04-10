#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
int* c;
int s;

int* suma(int n) {
    int a[10], b[10], c[10], s = 0;
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
    return c;
}

int n;

int main() {
    s = 0;
    cin >> n;
    c = suma(n);
    cout << "\nSum:" << s;
    return 0;
}