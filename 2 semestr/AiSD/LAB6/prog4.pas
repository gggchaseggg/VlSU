Type PElem =  ^TElem;
     TElem = record
           Info : integer;
           Next : PElem;
     end;  

{Подсчет кол-ва вхождений key}
procedure countKey( E : PElem; key : integer; var k : integer);
begin
  k := 0;
  while E<>nil do begin
      if E^.info = key then k := k+1;
      E := E^.next
  end;
end;

{Добавить один элемент в конец списка}
procedure add(var H : PElem; x : integer);
var E : PElem;
begin
  if H = nil then begin 
    new(H);
    H^.info := x;
    H^.next := nil;
  end
  else begin
    E := H;
    while E^.next <> nil do E := E^.next;
    new(E^.next);
    E := E^.next;
    E^.info := x;
    E^.next := nil    
  end;
end;

{создание очереди}
procedure createQweue (var H: PElem);
var x : integer;
begin
  H := nil;
  read(x);
  while x <> 0 do begin
     add(H, x);
     read(x);   
  end;
end;

{вывод списка}
procedure print(H : PElem);
begin
  while H <> nil do begin
    write(H^.info,' ');
    H := H^.next 
  end;
  writeln;
end;

{  подсчет кол-ва элементов, равных ключу  }
Var Q, E :  PElem; 
x, key, k : integer;

Begin
  Q := nil;
  
  createQweue(Q);
  print(Q);
  
  write('key = '); readln(key);
  
  countKey(Q,key, k);  
  writeln(k);
  
end.  
