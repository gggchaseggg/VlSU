program steki_lr2;
uses crt;
type
    pitem = ^item;
    item = record
        dat: integer;
        pr: pitem
    end;
var verh, el: pitem; d,a,i:integer;

function inits:integer;  
begin
   verh:=nil;
end;

function oshist:integer; 
begin
   verh:=nil;
end;
 
function vvod(x:integer):integer; 
begin
    new(el);
    el^.dat:= x;
    el^.pr:= verh;
    verh:=el;
end;
 
procedure vivod;  
begin
    writeln('Стэк:');
    el:=verh;
    while el<>nil do begin
        write(el^.dat,'   ');
        el:= el^.pr;
    end;
    writeln;
end;

Function Kol:integer;
Var k:integer;
Begin
     el := verh;
     k:=0;
     While el<>nil do  
     Begin
        k := k + 1;
        el:= el^.pr;
     End;
     Kol:=k;
End;

BEGIN
   clrscr;
   inits;
   for i:=1 to 10 do begin
    vvod(i);
   end;
   vivod;
   write('Введите добавляемое в стек значение: '); readln(a);
   vvod(a);
   vivod;
   writeln('Количество элементов стека: ',Kol);
   oshist;
END.