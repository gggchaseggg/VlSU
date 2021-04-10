#include <iostream>
using namespace std;
int a, b, c, u;
int main() {
    cin >> a >> b >> c;
    if ((a + b > c) and (a + c > b) and (c + b > a)) {
        if ((a*a + b*b == c*c) or (a*a + c*c == b*b) or (b*b + c*c == a*a)) {
            u = 1;
        }
        else {
            u = 0;
        }
    }
    else {
        u = -1;
    }
    cout << a << " " << b << " " << c << " " << u;
    return 0;
}