namespace XuLyVaCham
{
    public partial class Form1 : Form
    {
        bool moveLeft, moveRight,moveUp,moveDown;//dừng để check xem người dùng nhập phím nào
        int speed = 12;//tốc độ 
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //xử lý sự kiện cho các phím 
            if (moveLeft==true && player.Left>0)
            {
                player.Left -=speed;//sang trái thì trừ đi tốc độ
            }
            if (moveRight==true&&player.Left<677)
            {
                player.Left += speed;//sang phải thì cộng thêm tốc độ
            }
            if (moveUp == true && player.Top > 0)
            {
                player.Top -=speed;//lên trên thì trừ đi tốc độ
            }
            if (moveDown == true && player.Top < 334 )
            {
                player.Top +=speed;//xuống dưới thì cộng thêm tốc độ
            }

            //xử lý va chạm
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag=="object")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds))//nếu có va chạm
                    {
                        x.BackColor= Color.White;
                        label1.Text = x.Name;
                    }
                    else
                    {
                        x.BackColor= Color.Yellow;
                    }
                }
            }

        }

        //khi ta nhấn 1 phím xuống (chưa nhả phím ra)
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                moveLeft= true;
            }
            if(e.KeyCode == Keys.Right)
            {
                moveRight= true;
            }
            if(e.KeyCode == Keys.Up)
            {
                moveUp= true;
            }
            if(e.KeyCode==Keys.Down) 
            {
                moveDown= true;
            }
            
        }

        //khi ta nhả phím ra (phải trả về trạng thái ban đầu cho phím)
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
        }
    }
}