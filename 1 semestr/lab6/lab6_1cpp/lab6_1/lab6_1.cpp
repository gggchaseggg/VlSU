#include <iostream>
#include <cmath>
using namespace std;

void tabul() {
    double b = 1.5, x = 0.1, y;
    while ((x >= 0.1) and (x <= 1.1)) {
        if (b * x < 1) {
            y = (b * x - log10(b * x));
        }
        else if (b * x > 1) {
            y = (b * x + log10(b * x));
        }
        else {
            y = 1;
        }
        cout << "x = " << x << " y = " << round(y * 1000) / 1000 << endl;
        x = x + 0.1;
    }
}

int main() {
    tabul();
}