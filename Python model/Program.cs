while True:
  print("")
  print("===================================================")
  print("")
  def welcome_message():
      print("Welcome to Copington Adventure Theme Park!")
      print("Let's get your tickets ready.")
      print("")
      print("===================================================")
  
  
  def adult_total():
      while True:
          try:
              adult_count = int(input("1 adult ticket is £20. How many adult tickets would you like to get? "))
              adult_cost = adult_count * 20
              if adult_count >= 0:
                  print("Adult ticket cost is £", adult_cost, ".")
                  print("-------------------------------------------------")
                  return adult_cost
              else:
                  print("Please enter a valid number of tickets (0 or more).")
          except ValueError:
              print("Please enter a valid number.")
  
  
  def child_total():
      while True:
          try:
              child_count = int(input("1 child ticket is £12, how many child tickets would you like to get? "))
              child_cost = child_count * 12
              if child_count >= 0:
                  print("Child ticket cost is £", child_cost, ".")
                  print("-------------------------------------------------")
                  return child_cost
              else:
                  print("Please enter a valid number of tickets (0 or more).")
          except ValueError:
              print("Please enter a valid number.")
  
  
  def senior_total():
      while True:
          try:
              senior_count = int(input("1 senior ticket is £11, how many senior tickets would you like to get? "))
              senior_cost = senior_count * 11
              if senior_count >= 0:
                  print("Senior citizen ticket cost is £", senior_cost, ".")
                  print("-------------------------------------------------")
                  return senior_cost
              else:
                  print("Please enter a valid number of tickets (0 or more).")
          except ValueError:
              print("Please enter a valid number.")
  
  
  def entrance():
      total_adult_cost = adult_total()
      total_child_cost = child_total()
      total_senior_cost = senior_total()
      total_cost = total_adult_cost + total_child_cost + total_senior_cost
      print("Total ticket cost is £", total_cost, ".")
      return total_cost
  
  
  def wristband():
      while True:
          try:
              wrist_total = int(input("How many visitors would like a wristband for the rides? Each wristband is £20: "))
              if wrist_total >= 0:
                  wristband_cost = wrist_total * 20
                  print("Total wristband cost is £", wristband_cost, ".")
                  print("-------------------------------------------------")
                  return wristband_cost
              else:
                  print("Please enter a valid number of wristbands (0 or more).")
          except ValueError:
              print("Invalid input. Please enter a valid number.")
  
  
  def lead_surname():
      while True:
          surname = input("What is the surname of the lead booker? ")
          print("-------------------------------------------------")
          if len(surname) > 0 and not surname.isspace():
              return surname.capitalize()
          else:
              print("Please provide a valid Surname! It should not contain any spaces.")
  
  
  def parking():
      while True:
          required = input("Would you like to add parking for free? (yes/no): ").lower()
          print("-------------------------------------------------")
          if required in ["yes", "no"]:
              return required == "yes"
          else:
              print("Please answer with 'yes' or 'no'.")
  
  
  def note_input(total_cost):
      print("Your total cost is £", total_cost, ". The machine only accepts £10 and £20 notes.")
      total_paid = 0
  
      while total_paid < total_cost:
          try:
              note = int(input("Please insert a £10 or £20 note: "))
              if note == 10 or note == 20:
                  total_paid += note
                  print("You have inserted £", note, ". Total paid so far: £", total_paid, ".")
                  if total_paid < total_cost:
                      print("You need to pay £", total_cost - total_paid, " more.")
              else:
                  print("Invalid note. Please insert either £10 or £20 notes.")
          except ValueError:
              print("Invalid input. Please insert either £10 or £20 notes.")
  
      change = total_paid - total_cost
      if change > 0:
          print("Payment complete! Your change is £", change, ".")
      else:
          print("Payment complete! No change required.")
      return total_paid
  
  
  def main():
      welcome_message()
      ticket_cost = entrance()
      wristband_cost = wristband()
      surname = lead_surname()
      required = parking()
      parking_cost = 0 if required else 0
      total_cost = ticket_cost + wristband_cost + parking_cost
      print("Your final total is £", total_cost)
      note_input(total_cost)
      print("\n" + "=" * 50)
      print(" Copington Adventure Theme Park - Ticket for ", surname)
      print(" Total Ticket Cost: £", ticket_cost)
      print(" Total Wristband Cost: £", wristband_cost)
      print(" Parking: ", "£0" if required else "Not required")
      print(" Total Paid: £", total_cost)
      print("\nThank you for your purchase! Enjoy your visit to Copington Adventure Theme Park!")
      print("===================================================")
      print("")
      print("Next customer please!")
      print("")
      print("===================================================")
      count = main() + 1
      print(count)
      if count >= 500:
        print("This machine does not work anymore as the number of tickets are more than 500.")
      else:
        print("Hi!")
  
  
  if __name__ == "__main__":
      main()
