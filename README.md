# Mastermind Game

## 🔗 **Github Repository Link**

https://github.com/besmelh/mastermind-game

---

## 📝 **Description**

This is a console implementation of the classic **Mastermind** written in **C#**.

---

## 🎮 **Gameplay Rules**

- The secret code consists of **4 distinct digits** from **0 to 8**.
- The player has a default of **10 attempts** to guess the code.
- After each guess, the program displays:
  - **Well placed pieces:** correct digits in the correct position.
  - **Misplaced pieces:** correct digits but in the wrong position.
- The player wins when all 4 digits are well placed.
- Input ends gracefully upon **EOF signal (Ctrl+D or Ctrl+Z + Enter)**.

---

## 🚀 **Building the Project**

Ensure you have **.NET SDK installed** (version 6.0 or above).

1. Clone or download this repository.
2. Open terminal in the root directory.
3. `cd Mastermind`
4. `dotnet publish -c Release -o ./publish`

---

## ▶️ Running the Program

After building, execute the program as follows:

```bash
publish/Mastermind -c [CODE] -t [ATTEMPTS]
```

Example:

```bash
publish/Mastermind -c "0123" -t 8
```

---

## ⚙️ **Program Arguments**

- `-c [CODE]`: Specifies the secret code (must be 4 distinct digits from 0-8). If not provided, a random code is generated. Example: `-c "0123"`.
- `-t [ATTEMPTS]`: Specifies the number of attempts allowed. Defaults to **10** if not provided.Example: `-t 10`.
