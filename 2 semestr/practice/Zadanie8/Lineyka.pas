uses GraphABC;
type Tcoord = array of Point;
     TMatSmeg = array[,] of byte; 
var coord : Tcoord;
    n : integer;
    W : TMatSmeg;
    stek : array of integer;
    color : array of boolean;
    
procedure newCoordGraph(var coord: Tcoord; n : integer);
var i : integer; dx,dy,dxLastLine : integer; x,y,kLastLine : integer;
    sqrN : integer;
begin
   setlength(Coord,n);
   sqrN := Trunc(sqrt(n));
   dx := (WindowWidth div sqrN)-5;
   dy := (WindowHeight div (sqrN+1))-5;
   kLastLine  := n - sqr(sqrN);
   if kLastLine <> 0 then 
      dxLastLine := WindowWidth div kLastLine
   else dxLastLine := 0;
   
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
    W[v,u] := 1; W[u,v] := 1;
  end;

end;

procedure drawgraph(W:TMatSmeg; coord : TCoord; n : integer);
var v,u : integer;
begin
   for v := 0 to n-1 do 
    for u := 0 to n-1 do begin
     pen.width := 1;
     {if (W[v,u] = 1) and (W[u,v] = 1)
     then pen.Width := 3; 
     }if (W[v,u] = 1) or (W[u,v]=1)  then
     line(Coord[v].x,coord[v].y,coord[u].x,coord[u].y);
   end;
   pen.width := 1;
   
   for v := 0 to n-1 do 
   begin circle(coord[v].x,coord[v].y, 2);
         textout(coord[v].x,coord[v].y, inttostr(v)); 
   end;      
end;

procedure dfs(v,k : integer; var res : boolean);
var u : integer;
begin
   color[v] := false;
   inc(k); stek[k] := v;
   if (k = n-1) and (W[stek[k],stek[0]] = 1) then res := true
   else begin
      for u := 0 to n-1 do begin
          if (W[v,u] = 1) and color[u] then dfs(u,k,res); 
      end;     
      dec(k);     
      color[v] := true;     
   end;   
end;    

begin    
 readln(n);
 inputGraph(W,n,'Data.txt');
  newCoordGraph(coord,n);
  drawgraph(W,coord,n);
 
  setlength(stek,n);
  setlength(color,n);
  var i,k,v : integer;
  var res : boolean := false;
  for i := 0 to n-1 do begin
    color[i] := true;
    stek[i]:= 0;
  end;
  
  k := -1;
  for i := 0 to n-1 do begin 
    if color[i] then dfs(i,k,res);
    if res then break;
  end;
  
  pen.Width := 3;
  if res then begin
    for i := 0 to n-2 do begin 
      write(stek[i],'_'); 
            line(coord[stek[i]].X,  coord[stek[i]].Y,
                 coord[stek[i+1]].X,coord[stek[i+1]].Y);
    end;
    line(coord[stek[n-1]].X,  coord[stek[n-1]].Y,
         coord[stek[0]].X,    coord[stek[0]].Y);
    write(stek[n-1],'_');
  end  
  else writeln('not');
   
end.    