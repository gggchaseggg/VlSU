uses GraphABC;
const namefile = 'Data.txt';
type PList = record
      v,p : integer;
      next : ^PList;
     end; 

var n : integer;
    W : array of ^PList; {глоб.перемен.}
    koord : array of Point;
var Q : ^PList;

procedure add(var H : ^PList; x : integer; p:integer := 0);
var E : ^PList;
begin
  if H = nil 
  then  begin  new(H); 
               H^.next := nil; H^.v := x; H^.p := p;
        end
  else  begin      
         E := H;
         while E^.Next <> nil do E := E^.Next;             
         new(E^.Next);
         E:= E^.Next;
         E^.Next := nil;
         E^.v := x; E^.p := p;
        end;
end;
    
procedure push(var H : ^PList; v : integer);
var E : ^PList;
begin
 new(E); E^.v := v; E^.Next := H; H := E;
end; 

procedure del(var H : ^PList);
var E : ^PList;
begin
  while H <> nil do begin
      E := H^.Next; dispose(H); H := E;      
  end; 
end;   

procedure readfile;
var f : text; s : string; v,u : integer;
begin
    Assign(f, namefile);
    reset(f);
    readln(f,n); setlength(W,n);
    for v := 0 to High(W) do W[v] := nil;    
    
    while not Eof(f) do begin
      readln(f,s);
      v := strtoint(copy(s,1,pos(' ',s)-1));
      delete(s,1,pos(' ',s));
      u := strtoint(s);
      add(W[v],u);
      add(W[u],v);
    end;
    close(f);
end;

procedure koord_random;
var v : integer;
begin
  randomize; 
  setlength(koord,n);
  for v := 0 to High(W) do begin
    koord[v].x := random(WindowWidth -20) +10;
    koord[v].y := random(WindowHeight - 20) + 10;
  end;

end;

procedure drawgraph;
var v,u : integer; E :^PList;
begin
  Window.Clear;
  
  for v := 0 to High(W) do begin

    E := W[v];
    while E <> nil do begin
       u := E^.v;
       if u < v then Line(koord[v].x,koord[v].y,
                          koord[u].x,koord[u].y);
       E := E^.next;
    end;
  end;
  for v := 0 to High(W) do begin
     TextOut(koord[v].X,koord[v].Y, inttostr(v) );
     Circle(koord[v].x ,koord[v].y, 2);
     
  end;   
end;

procedure drawgraph_new;
var v,u : integer; E :^PList;
begin
 { Window.Clear;}
 
  for v := 0 to High(W) do begin
    E := W[v];
    while E <> nil do begin
       u := E^.v;
       if u < v then Line(koord[v].x,koord[v].y,
                          koord[u].x,koord[u].y);
       E := E^.next;
    end;
  end;
  for v := 0 to High(W) do begin
     TextOut(koord[v].X,koord[v].Y, inttostr(v) );
     Circle(koord[v].x ,koord[v].y, 2);
  end;   
end;


procedure VA(var Q : ^PList; var z : integer);
var E: ^PList; U: ^PList;
    color : array of byte;
    i : integer;
begin
    setlength(color,N);
    for i := 0 to High(color) do color[i] := 0;
    add(Q,0,-1); color[0] := 1;
    add(Q,-1); z := 0;
    E := Q;
    while E^.Next <> nil do begin
      if E^.V = -1 
      then begin add(Q,-1); inc(z) end
      else begin
             U := W[ E^.V ];
             while U <> nil do begin
                if color[ U^.v] = 0 then 
                begin  add(Q, U^.v, E^.v); color[U^.v] := 1;   end;
                U := U^.Next;
             end;
           end;  
      E := E^.Next;    
    end;
end;

procedure viewQ( H : ^PList);
begin
    while H <> nil do 
    begin writeln(H^.V,' ',H^.p); H := H^.next end;
end;

procedure reKoord(z: integer; Q : ^PList);
var x,i,y : integer; dx,dy : integer; E : ^PList;
    urov : array of integer; max : integer;
begin
  setlength(urov,n); E := Q;
  for i := 0 to High(urov) do urov[i] := 0;
  x := 0;
  dx := WindowWidth div (z+2);
  while Q^.next <> nil do begin
     if Q^.v = -1 
     then inc(x)
     else begin inc(urov[x]); koord[Q^.v].X := x*dx + dx; end;
     Q := Q^.next;    
  end;

  x := 0;
  y := 0; dy := WindowHeight div 2;
  while E^.next <> nil do begin
     if E^.v = -1 
     then begin 
             y := 0; inc(x); 
             dy := WindowHeight div (urov[x] + 1) end
     else begin inc(y); koord[E^.v].Y := y*dy  end;
     E := E^.next;    
  end;
end;

procedure back_stroke(Q:^PList);
var v,u : integer; E : ^PList;
begin
   pen.Color := clred;
   pen.Width := 3;
   readln(u);
   while true do begin
      E := Q;
      while E^.v <> u do E := E^.next;
      v := E^.p;
      line(koord[v].X,koord[v].Y,koord[u].X,koord[u].Y);
      TextOut(koord[v].X,koord[v].Y, inttostr(v) );
      Circle(koord[v].x ,koord[v].y, 2);
      TextOut(koord[u].X,koord[u].Y, inttostr(u) );
      Circle(koord[u].x ,koord[u].y, 2);
      u := v;
      if v = 0 then exit;
   end;
end;



begin
    readfile; 
    koord_random;
    drawgraph;
    
    
    var v,z : integer;
    readln(z);
    Window.Clear;
    
    z := 0;
    Q := nil;
    VA(Q,z);
    viewQ(Q); TextOut(10,10,inttostr(z)); 
    reKoord(z,Q);   
    drawgraph_new; 
    back_stroke(Q);
    for v := 0 to High(W) do del(W[v]);
    W := nil;
end.