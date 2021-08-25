uses GraphABC;
type 
     Tcoord = array of Point; 
     
     TRebra = record
       x,y : integer;
       w : integer
     end;
     
var coord : Tcoord;
    n : integer;
     
    color : array of boolean;
    R, Ostov : array of TRebra;
    stek : array of integer;
    A : array of array of integer;
    
    
 
 
procedure test_cicle(stek : array of integer; v : integer);
var cicle, cicle_w : array of integer;
    k,i,j,t, k_len : integer;
    min,max : integer;
    f,ff : boolean;
begin
  // write('stek=',stek,' ');
    k := high(stek);
    while stek[k] <> v do dec(k);
    k_len := high(stek) - k + 1; 
 
 if k_len >= 3 then begin
    
   
    setlength(cicle,   k_len);
    setlength(cicle_w, k_len);    
    min := stek[high(stek)];
    max := stek[high(stek)];
    for i := 0 to k_len-1 do begin 
                                 cicle[i] := stek[i+k];
                                 cicle_w[i] := stek[i+k];
                                 if min > cicle[i] then min := cicle[i];
                                 if max < cicle_w[i] then max := cicle_w[i];
                             end;    
   // write(cicle,cicle_w);
    while cicle[0] <> min do begin
      i := cicle[0];
      for j := 0 to high(cicle)-1 do cicle[j] := cicle[j+1];
      cicle[high(cicle)] := i
    end; 
    while cicle_w[0] <> max do begin
      i := cicle_w[0];
      for j := 0 to high(cicle_w)-1 do cicle_w[j] := cicle_w[j+1];
      cicle_w[high(cicle_w)] := i
    end;     
    
  //  writeln('---',cicle,cicle_w);
    ff := false;
    for i := 0 to high(A) do begin
       
        if high(A[i]) = high(cicle) then begin 
            f := true;
            for j := 0 to high(A[i]) do 
                if A[i][j] <> cicle[j] then f := false ;
            if f then break;
       
            f := true;
            for j := 0 to high(A[i]) do 
                if A[i][j] <> cicle_w[j] then f := false ;
            if f then break; 
        
        end;
    end;
    ff := f;

{   ff := false;
   for i := 0 to high(A) do begin
     
     if high(A[i]) = high(cicle) then begin
       ff := true;
       for j := 0 to high(A[i]) do begin
         f := false;
         for t := 0 to high(cicle)  do
           if A[i][j] = cicle[t] then f:= true;
         ff := ff and f
       end;
       if ff then break; 
     end
     
   end;  
}    
    
    if not ff then begin
     // writeln(stek);
      setlength(A,high(A)+2);
      i := high(A);
      setlength(A[i],high(cicle)+1);
      for j:= 0 to high(cicle) do A[i,j] := cicle[j];
      
      setlength(A,high(A)+2);
      i := high(A);
      setlength(A[i],high(cicle_w)+1);
      for j:= 0 to high(cicle) do A[i,j] := cicle_w[j];
    end;
  end;
end; 
    

function dfs(Z: array of TRebra; v : integer; p : integer;
             var color : array of boolean; 
             var stek: array of integer; var k : integer) : boolean;
var i,j : integer;
    f : boolean;
begin
   f := true;
   color[v] := true;
   inc(k); 
   setlength(stek,k+1);
   stek[k] := v;
    
   for i := 0 to high(Z) do begin
      if (v = Z[i].x) and (not(color[Z[i].y])) and (p <> Z[i].y)  then begin f := dfs(Z,Z[i].y,v,color,stek,k); 
      end
      else
      if (v = Z[i].y) and (not(color[Z[i].x])) and (p <> Z[i].x)  then begin f := dfs(Z,Z[i].x,v,color,stek,k); 
      end
      else
   
      if (v = Z[i].x) and (color[Z[i].y]) and (p <> Z[i].y)  then begin 
           j := k;
           //test_cicle(stek,Z[i].y);
           while (j > 0) and (stek[j] <> Z[i].y) do begin write(stek[j],' '); j := j - 1 end;
           writeln(stek[j],' ');  
           f := false;  
           end
      else      
           
      if (v = Z[i].y) and (color[Z[i].x]) and (p <> Z[i].x) then begin 
           j := k;
           //test_cicle(stek,Z[i].x);
           while (j > 0) and (stek[j] <> Z[i].x) do begin write(stek[j],' '); j := j - 1 end;  
           writeln(stek[j],' ');   
           f := false;   
           end;
       
   end; 
   
  color[v] := false;
  setlength(stek,k);
  k := k - 1;
 
  result := f 
end;

procedure newCoordGraph(var coord: Tcoord; n : integer);
var i : integer; dx,dy,dxLastLine : integer; x,y,kLastLine : integer;
    sqrN : integer;
begin
   setlength(Coord,n);
   sqrN := Trunc(sqrt(n));
   dx := (WindowWidth div sqrN)-5;
   dy := (WindowHeight div (sqrN+1))-5;
   kLastLine  := n - sqr(sqrN);
   if kLastLine <> 0 then  dxLastLine := WindowWidth div kLastLine else dxLastLine:=0;
   
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

procedure inputGraph(var R: array of TRebra; var n: integer; s: string);
var f : text; v,u,k,i : integer; A : TRebra; 
begin
  assign(f,s);
  reset(f);
  readln(f,n);
  
  newCoordGraph(coord,n);
  
  k := 0;  
  while not eof(f) do begin
    readln(f,s);
    v := strtoint( copy(s,1,pos(' ',s)-1) );
    delete(s,1, pos(' ',s));
    u := strtoint( s );
    setlength(R, k+1);
    A.x := min(v,u); A.y := max(v,u); 
    A.w := round(sqrt(sqr(coord[v].X - coord[u].X) + sqr(coord[v].Y - coord[u].Y)));
    i := k;
    while (i-1 >= 0) and (A.x < R[i-1].x) do begin R[i] := R[i-1]; dec(i); end;
    R[i] := A;
    inc(k);
  end;
  
  for i := 0 to high(R) do writeln( R[i].x,' ', R[i].y, '  ',R[i].w );
  writeln;

end;

procedure drawgraph( R : array of TRebra; coord : TCoord; n : integer);
var i : integer;
begin 
   pen.width := 1;
   for i := 0 to high(R) do begin
     line(Coord[ R[i].x ].x, coord[ R[i].x ].y, coord[ R[i].y ].x, coord[ R[i].y ].y);
   end;   
   
   for i := 0 to n-1 do 
   begin circle(coord[i].x,coord[i].y, 5);
         textout(coord[i].x,coord[i].y, inttostr(i)); 
   end;      
end;



begin    
 readln(n);
 inputGraph(R,n,'Data.txt');
 
  drawgraph(R,coord,n);
 
  var i,k,v : integer;

  k := -1;
   
  writeln;
  
  setlength(color,n);
  setlength(stek,n);
  for i := 0 to n-1 do begin color[i] := false; stek[i] := 0 end;
  writeln;
  for i := 0 to n-1 do 
      dfs(R,i,-1,color,stek,k);
  
  for i := 0 to high(A) do
    if i mod 2 = 0 then
      writeln(A[i]);

end.    