unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    procedure coh(x1, y1, x2, y2, it: integer);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.coh(x1, y1, x2, y2, it: integer);
var
  x1_3, y1_3, x2_3, y2_3: integer;
  xs,ys: integer;
  r, cosa, sina, xa, ya: real;
begin
  if it = 0 then exit;
  canvas.Pen.Color := clblack;
  canvas.Pen.Width := 1;
  Canvas.MoveTo(x1, y1);
  Canvas.LineTo(x2, y2);
  x1_3 := x1 + (x2-x1) div 3;
  y1_3 := y1 + (y2-y1) div 3;
  x2_3 := x1 + 2*(x2-x1) div 3;
  y2_3 := y1 + 2*(y2-y1) div 3;
  r := sqrt(sqr(x1_3-x2_3) + sqr(y1_3-y2_3));
  xa := r/2;
  ya := r*sqrt(3)/2;
  cosa := (x2_3-x1_3)/r;
  sina := (y2_3-y1_3)/r;
  xs := round((xa*cosa) - (ya*sina));
  ys := round((xa*sina) + (ya*cosa));
  Canvas.MoveTo(xs+x1_3, ys+y1_3);
  Canvas.LineTo(x1_3, y1_3);
  Canvas.MoveTo(xs+x1_3, ys+y1_3);
  Canvas.LineTo(x2_3, y2_3);
  canvas.Pen.Color := clBtnFace;
  canvas.Pen.Width := 2;
  Canvas.MoveTo(x1_3, y1_3);
  Canvas.LineTo(x2_3, y2_3);
//  sleep(100);
  coh(x1, y1, x1_3, y1_3, it-1);
  coh(x1_3, y1_3, xs+x1_3, ys+y1_3, it-1);
  coh(xs+x1_3, ys+y1_3, x2_3, y2_3, it-1);
  coh(x2_3, y2_3, x2, y2, it-1);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  coh(600, 200, 200, 200, 4);
  coh(200, 200, 200, 600, 4);
  coh(200, 600, 600, 600, 4);
  coh(600, 600, 600, 200, 4);
end;

end.
