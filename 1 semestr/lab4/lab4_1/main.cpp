#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
int n=10, a[10] , mn = a[0], ind, v;
int main() {
    srand(time(NULL));
    cout << "Array: ";
    for (int i = 0; i < n; i++) {
        a[i] = rand() % 101 - 50;
        cout << a[i] << " ";
        if (a[i] < mn) {
            mn = a[i];
            ind = i;
        }
    }
    if (ind == (n-1)){
        v = 1;
    }
    else {
        v = 0;
    }
    cout << "\nMinimum:" << mn << "\nIndex: " << ind << "\nV = " << v;
    return 0;
}
