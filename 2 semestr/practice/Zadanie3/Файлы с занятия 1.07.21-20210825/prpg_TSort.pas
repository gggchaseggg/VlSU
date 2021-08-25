uses GraphABC;
type TMatr = array[,] of integer;
 TPoint = record
 x,y : integer;
 end;
 TCoordV = array of TPoint;

var A: TMatr; C : TCoordV;
 color:array of integer; {0-white, 1-grey, 2-black}
 list:array of integer; n,num: integer;
{Генерация координат вершин графа}
procedure generet_coord(var C:TCoordV; z, x,a,y,b: integer);
begin
 C[z].x := random(x, x+a);
 C[z].y := random(y, y+b);
end;
{Разделение экрана на части, для размещения внутри вершин графа}
procedure new_coord(var C : TCoordV);
var ni,nj : integer; n : integer; a,b : integer; x,y : integer; z : integer;
begin
 randomize;
 n := High(C);
 ni := trunc(sqrt(n));
 nj := ni + 1;
 if sqr(trunc(sqrt(n))) = n then nj := ni
 else
 if ni*nj < n then ni := ni + 1;
 a := (WindowWidth-100) div nj;
 b := (WindowHeight-100) div ni;
 x := 50; y := 50; z := 1;
 for var i := 1 to ni do begin
 for var j := 1 to nj do begin
 generet_coord(C,z,x,a,y,b);
 x := (x + a) mod (WindowWidth-100);
 z := z + 1;
 if z > n then exit
 end;
 y := y + b ;
 end;
end;
{Ввод графа из файла}
procedure read_Matr(var A: TMatr; s: string; var C:TCoordV);
var x,y:integer; f:text;
begin
 assign(f,s); reset(f); readln(f,n); setlength(A,n+1,n+1);
 for var i := 0 to high(A) do
 for var j := 0 to high(A) do A[i,j] := 0;
 while not eof(f) do begin
 readln(f,s);
 x := strtoint(copy(s,1,pos(' ',s) - 1));
 y := strtoint(copy(s,pos(' ',s) + 1, length(s) ));
 A[x,y] := 1; {A[y,x] := 1;}
 end;
 SetLength(C,n+1); new_coord(C);
 close(f);
end;
{Изображение графа}
procedure draw_Graph(A:TMatr; C : TCoordV);
var x1,y1:integer;
begin
 for var i:= 1 to High(A) do
 for var j := 1 to High(A) do
 if i<=j
 then if A[i,j] = 1 then begin
 line(C[i].x,C[i].y,C[j].x,C[j].y);
 x1:=(C[i].x+C[j].x)div 2; x1:=(x1+C[j].x)div 2;
 y1:=(C[i].y+C[j].y)div 2; y1:=(y1+C[j].y)div 2;
 setpenwidth(3);
 line(x1,y1,C[j].x,C[j].y);
 setpenwidth(1);
 end
 else if A[j,i] = 1 then begin
 line(C[j].x,C[j].y,C[i].x,C[i].y);
 x1:=(C[i].x+C[j].x)div 2; x1:=(x1+C[j].x)div 2;
 y1:=(C[i].y+C[j].y)div 2; y1:=(y1+C[j].y)div 2;
 setpenwidth(3);
 line(x1,y1,C[j].x,C[j].y);
 setpenwidth(1);
 end;
 for var i := 1 to High(A) do begin
 circle(C[i].x,C[i].y,14);
 if i < 10
 then TextOut(C[i].x-3,C[i].y-4, inttostr(i) )
 else TextOut(C[i].x-5,C[i].y-4, inttostr(i) )
 end;
end;
procedure dfs(v:integer; var num: integer; A:TMatr; var color: array of
integer; var List: array of integer);
begin
 color[v]:=1; {Открываем вершину, закрасив её в серый}
 for var u:=1 to high(A) do {От первой вершины до последней}
 if (color[u]=0)and(A[v,u]<>0) then dfs(u,num,A,color,list) {Запускаем
обход от вершины u}
 else if (color[u]=1)and(A[v,u]<>0) then break;
 inc(num); list[n-num+1]:=v;
 color[v]:=2; {Закрываем вершину, закрашиваем в черный}
end;
begin
 read_Matr(A,'Data.txt',C); {Вводим графи из файла}
readln;
 draw_Graph(A,C); {Изображаем граф}
 writeln;

 readln;
 setlength(color,n+1);
 setlength(list,n+1);
 for var v:=1 to n do begin
 color[v]:=0; list[v]:=0;
 end;
 num:=0;

 for var v:=1 to n do
 if color[v]=0 then dfs(v,num,A,color,list);

 writeln('Топологическая сортировка:');
 for var v:=1 to n do write(list[v],' ');
end.
