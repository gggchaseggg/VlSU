#include <iostream>
#include <ctime>
#include <cmath>
using namespace std;


float element(int x) {
    srand(time(NULL));
    int a[100] = { 0,1 };
    for (int i = 2; i < x+1; i++) {
        a[i] = a[i-2]+a[i-1];
    }
    return a[x];
}

int k, n;
float s;

int main()
{
    cin >> k;
    cin >> n;
    s = element(k) / element(n);
    cout << round(s * 1000) / 1000;
}
