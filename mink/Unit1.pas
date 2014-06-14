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
    procedure minkovskiy(x1, y1, x2, y2, it: integer);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.minkovskiy(x1, y1, x2, y2, it: integer);
var
  x1_1, y1_1: integer;
  x1_2, y1_2: integer;
  x1_3, y1_3: integer;
  x2_1, y2_1: integer;
  x2_2, y2_2: integer;
  x2_3, y2_3: integer;
  x2_4, y2_4: integer;
  xs,ys: integer;
  r, cosa, sina, xa, ya: real;
begin
  if it = 0 then exit;
  canvas.Pen.Color := clBtnFace;
  canvas.Pen.Width := 1;
  Canvas.MoveTo(x1, y1);
  Canvas.LineTo(x2, y2);
  x1_2 := x1 + (x2-x1) div 2;
  y1_2 := y1 + (y2-y1) div 2;
  x1_1 := x1 + (x1_2-x1) div 2;
  y1_1 := y1 + (y1_2-y1) div 2;
  x1_3 := x1_2 + (x2-x1_2) div 2;
  y1_3 := y1_2 + (y2-y1_2) div 2;
  canvas.Pen.Color := clBlack;
  canvas.Pen.Width := 1;
  Canvas.MoveTo(x1, y1);
  Canvas.LineTo(x1_1, y1_1);
  Canvas.MoveTo(x2, y2);
  Canvas.LineTo(x1_3, y1_3);
  r := sqrt(sqr(x1_1-x1_2) + sqr(y1_1-y1_2));
  xa := 0;
  ya := -r;
  cosa := (x1_2-x1_1)/r;
  sina := (y1_2-y1_1)/r;
  x2_1 := x1_1 + round((xa*cosa) - (ya*sina));
  y2_1 := y1_1 + round((xa*sina) + (ya*cosa));
  Canvas.MoveTo(x1_1, y1_1);
  Canvas.LineTo(x2_1, y2_1);
  x2_2 := x1_2 + round((xa*cosa) - (ya*sina));
  y2_2 := y1_2 + round((xa*sina) + (ya*cosa));
  Canvas.MoveTo(x2_1, y2_1);
  Canvas.LineTo(x2_2, y2_2);
  Canvas.MoveTo(x2_2, y2_2);
  Canvas.LineTo(x1_2, y1_2);
  xa := 0;
  ya := r;
  x2_3 := x1_2 + round((xa*cosa) - (ya*sina));
  y2_3 := y1_2 + round((xa*sina) + (ya*cosa));
  Canvas.MoveTo(x1_2, y1_2);
  Canvas.LineTo(x2_3, y2_3);
  x2_4 := x1_3 + round((xa*cosa) - (ya*sina));
  y2_4 := y1_3 + round((xa*sina) + (ya*cosa));
  Canvas.MoveTo(x2_3, y2_3);
  Canvas.LineTo(x2_4, y2_4);
  Canvas.MoveTo(x2_4, y2_4);
  Canvas.LineTo(x1_3, y1_3);
  minkovskiy(x1, y1, x1_1, y1_1, it-1);
  minkovskiy(x1_1, y1_1, x2_1, y2_1, it-1);
  minkovskiy(x2_1, y2_1, x2_2, y2_2, it-1);
  minkovskiy(x2_2, y2_2, x1_2, y1_2, it-1);
  minkovskiy(x1_2, y1_2, x2_3, y2_3, it-1);
  minkovskiy(x2_3, y2_3, x2_4, y2_4, it-1);
  minkovskiy(x2_4, y2_4, x1_3, y1_3, it-1);
  minkovskiy(x1_3, y1_3, x2, y2, it-1);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  minkovskiy(200, 400, 600, 400, 3);
end;

end.
