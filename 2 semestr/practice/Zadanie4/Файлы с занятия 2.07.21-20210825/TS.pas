uses GraphABC;
type Tcoord = array of Point;
     TMatSmeg = array[,] of byte; 
var coord : Tcoord;
    n : integer;
    W : TMatSmeg;
    up : array of integer;
    d : array of integer;
    ch : array of integer;
    time : integer:= 0;
    res :array of boolean;

procedure newCoordGraph(var coord: Tcoord; n : integer);
var i : integer; dx,dy,dxLastLine : integer; x,y,kLastLine : integer;
    sqrN : integer;
begin
   setlength(Coord,n);
   sqrN := Trunc(sqrt(n));
   dx := (WindowWidth div sqrN)-5;
   dy := (WindowHeight div (sqrN+1))-5;
   kLastLine  := n - sqr(sqrN);
   dxLastLine := WindowWidth div kLastLine;
   
   i := 0;
   for y := 1 to sqrN do
     for x := 1 to sqrN do begin
        coord[i].x := x*dx - random(dx);
        coord[i].y := y*dy - random(dy); inc(i);
     end;
     
   y := sqrN+1;
   for x := 1 to kLastLine do begin
        coord[i].x := x*dxLastLine - random(dxLastLine);
        coord[i].y := y*dy - random(dy); inc(i);
   end;
end;

procedure inputGraph(var W: TMatsmeg; var n: integer; s: string);
var f : text; v,u : integer;
begin
  assign(f,s);
  reset(f);
  readln(f,n);
  setlength(W,n,n);
  for v:= 0 to n-1 do
    for u := 0 to n-1 do W[v,u] := 0;
  
  while not eof(f) do begin
    readln(f,s);
    v := strtoint( copy(s,1,pos(' ',s)-1));
    delete(s,1, pos(' ',s));
    u := strtoint( s );
    W[v,u] := 1;
    W[u,v] := 1;
  end;

end;


procedure drawgraph(W:TMatSmeg; coord : TCoord; n : integer);
var v,u : integer;
begin
   for v := 0 to n-1 do 
    for u := v to n-1 do 
     if W[v,u] = 1 then line(Coord[v].x,coord[v].y,coord[u].x,coord[u].y);
   
   for v := 0 to n-1 do 
   begin circle(coord[v].x,coord[v].y, 3);
         textout(coord[v].x,coord[v].y, v); 
   end;      
end;


    
procedure dfs(v : integer);
var u : integer;
begin
   inc(time);  d[v] := time; 
   up[v] := n+1;
   for u := 0 to n-1 do 
   if W[v,u] = 1 then 
    if (d[u] = 0) then begin
      dfs(u); inc(ch[v]);
      up[v] := min(up[v],up[u]);
      if up[u] >= d[v] then res[v] := true
    end 
    else up[v] := min(up[v],d[u]);
end;    

procedure dfs1(v,p : integer);
var u : integer;
begin
   inc(time);d[v] := time;up[v] := time;
   for u := 0 to n-1 do 
   if (W[v,u] = 1) and (u<>p) then begin
    if (d[u] = 0) then begin
      dfs1(u,v); inc(ch[v]);
      up[v] := min(up[v],up[u]);
      if up[u] >= d[v] then res[v] := true
    end 
    else 
      if u<>p then up[v] := min(up[v],d[u]);
   end;   
   if p = -1 then res[v] := ch[v] > 1;   
end;    

begin    
  readln(n);
  inputGraph(W,n,'Data.txt');
  newCoordGraph(coord,n);
  drawgraph(W,coord,n);
  
  
  setlength(res,n);
  setlength(up,n);
  setlength(d,n);
  setlength(ch,n);
  var i : integer; 
  for i := 0 to n-1 do begin
    res[i] := false;
    up[i] := 0;
    d[i] := 0; 
    ch[i]:= 0;
  end;
 { 
  for i := 0 to n-1 do 
   if d[i] = 0 then begin 
      dfs(i);
      res[i] := ch[i] > 1;    
  end; 
 }  
  for i := 0 to n-1 do 
    if d[i] = 0 then dfs1(i,-1);
 
  Pen.color := clred;
  Pen.Width := 3;
  for i := 0 to n-1 do
    if res[i] then 
      circle(coord[i].x,coord[i].y,5);
      
  var v,u : integer;    
{  
  for v := 0 to n-1 do write(d[v]:4);
  writeln;
  for v := 0 to n-1 do write(up[v]:4);
}  
  {мосты}
  for v := 0 to n-1 do
    for u := 0 to n-1 do
     if (W[v,u] = 1) then
      if up[u] > d[v] then
      line(coord[v].X,coord[v].Y,
           coord[u].X,coord[u].Y);
  
      
end.    