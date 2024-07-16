namespace TicTacToe
{
    public partial class Board : Form
    {
        string playerOneName;
        string playerTwoName;
        byte playerOneScore;
        byte playerTwoScore;
        byte currentTurn;
        int[][] board;
        byte gridCount;

        public Board(string _playerOneName, string _playerTwoName)
        {
            InitializeComponent();
            this.playerOneName = string.IsNullOrEmpty(_playerOneName) ? "Player 1" : _playerOneName;
            this.playerTwoName = string.IsNullOrEmpty(_playerTwoName) ? "Player 2" : _playerTwoName;

            this.playerOneScore = 0;
            this.playerTwoScore = 0;
            this.currentTurn = 1;
            this.board = new int[3][];
            this.board[0] = new int[3];
            this.board[1] = new int[3];
            this.board[2] = new int[3];
            this.gridCount = 0;
        }

        private void Board_Load(object sender, EventArgs e)
        {
            lbl_playerOneName.Text = playerOneName + " score:";
            lbl_playerTwoName.Text = playerTwoName + " score:";
            lbl_playerOneScore.Text = playerOneScore.ToString();
            lbl_playerTwoScore.Text = playerTwoScore.ToString();
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            byte row = byte.Parse(button.Name.Split("_")[1]);
            byte col = byte.Parse(button.Name.Split("_")[2]);

            if (board[row][col] == 0)
            {
                gridCount++;
                board[row][col] = currentTurn;
                button.Text = currentTurn == 1 ? "X" : "O";
                button.ForeColor = currentTurn == 1 ? Color.Cyan : Color.DeepPink;
            }
            else { return; }


            if (CheckWinner())
            {
                MessageBox.Show("Player " + (currentTurn == 1 ? playerOneName : playerTwoName) + " wins!");
                if (currentTurn == 1)
                {
                    playerOneScore++;
                    lbl_playerOneScore.Text = playerOneScore.ToString();
                }
                else
                {
                    playerTwoScore++;
                    lbl_playerTwoScore.Text = playerTwoScore.ToString();
                }
                ResetBoard();
            }
            currentTurn = currentTurn == 1 ? (byte)2 : (byte)1;

            if (gridCount == 9)
            {
                MessageBox.Show("It's a draw!");
                ResetBoard();
            }
        }

        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i][0] == currentTurn && board[i][1] == currentTurn && board[i][2] == currentTurn)
                {
                    return true;
                }
                if (board[0][i] == currentTurn && board[1][i] == currentTurn && board[2][i] == currentTurn)
                {
                    return true;
                }
            }

            if (board[0][0] == currentTurn && board[1][1] == currentTurn && board[2][2] == currentTurn)
            {
                return true;
            }
            if (board[0][2] == currentTurn && board[1][1] == currentTurn && board[2][0] == currentTurn)
            {
                return true;
            }

            return false;
        }

        private void ResetBoard()
        {
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    control.Text = "";
                    control.ForeColor = Color.DodgerBlue;
                }
            }

            btn_reset.ForeColor = Color.Gold;
            btn_reset.Text = "Reset";

            btn_newGame.ForeColor = Color.Gold;
            btn_newGame.Text = "New Game";

            gridCount = 0;

            board = new int[3][];
            board[0] = new int[3];
            board[1] = new int[3];
            board[2] = new int[3];
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetBoard();
        }

        private void btn_newGame_Click(object sender, EventArgs e)
        {
            ResetBoard();
            playerOneScore = 0;
            playerTwoScore = 0;
            lbl_playerOneScore.Text = playerOneScore.ToString();
            lbl_playerTwoScore.Text = playerTwoScore.ToString();
            currentTurn = 1;
        }
    }
}
