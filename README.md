# 🧸 kindergarten Management App

## 📖 Project Description
This project is a **desktop application** for the "Jardin Paradis" kindergarten. It simplifies the **online registration process for children** and provides a **private management portal for the director**.

The app allows parents to:
- Sign up ("Inscription")
- Log in ("Connexion")
- View their child's file

The director can:
- Manage staff files ("fiche personnel")
- View financial reports ("Bilan")

## 🗂️ Project Structure
- **Application Type:** Windows Forms (WinForms) Desktop App.
- **Main Forms:**
  - `Form1`: Main Menu (Login, Sign-up, Private Account)
  - `Form3`: Inscription (Registration) Form
  - `Form2`: Connexion (Login) Form
  - `Form5`: Fiche d'enfant (Child's File)
  - `Form11`: Bilan (Financial Report)
- **Data Storage:**
  - All data is stored in **flat .txt files**.
  - `enfant.txt`: Stores child's subscription and details.
  - `parent.txt`: Stores parent's login and personal info.
  - `personnel.txt`: Stores staff info and salaries.

---

## ✨ Key Features
- **Parent Portal:**
  - Secure registration and login for parents.
  - Detailed registration form with subscription options (e.g., full-day, transport, clubs).
  - Ability to view their child's information file.
  - Generate and print a school attestation (diploma).
- **Director (Admin) Portal:**
  - Private, separate login for the director.
  - View and manage staff files and salaries ("fiche personnel").
  - Access a "Bilan" (Balance Sheet) to track finances.
- **Financial Reporting:**
  - The Bilan automatically calculates total income from student fees.
  - It also calculates total expenses from staff salaries.
  - Displays the final net profit ("NET").

---

## ✅ Strengths
- **User-Friendly:** Simple and intuitive interface for both parents and the director.
- **Efficient:** Simplifies the administrative workload for registration and financial tracking.
- **All-in-One:** Provides a complete solution for managing students, staff, and finances.

---

## 🚀 Installation & Usage
1. Clone the repository:
   ```bash
   git clone [https://github.com/YourUsername/YourRepoName.git](https://github.com/YourUsername/YourRepoName.git)
   ```

2. Open the solution file (.sln) in Visual Studio.
3. Ensure the .txt data files (enfant.txt, parent.txt, personnel.txt) are in the correct build directory (e.g., /bin/Debug/).
4. Press F5 or the "Start" button to run the application.
