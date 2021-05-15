def summa(n, k):
    def memoizе(funk):
        '''Мемоизация для оптимизации выполнения рекурсии'''
        cache = [[None] * k for j in range(n)]
        def wrapper(n, k):
            if cache[n-1][k-1] is None:
                cache[n-1][k-1] = funk(n, k)
            return cache[n-1][k-1]
        return wrapper
    
    @memoize
    def count_perm(n, k):
        '''По рекуррентной формуле для разбиения числа'''
        if n == k and n > 0:
            return 1
        elif n > 0 and k == 1:
            return 1
        elif k > n:
            return 0
        else:
            return count_perm(n-1, k-1) + count_perm(n-k, k)
    return count_perm(n,k)

n,k = map(int,input("Введите числа n и k(k < n) не превосходящие 120: ").split())

print(summa(n,k))
