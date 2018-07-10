# examples of tests done on application

# example input/output provided in the exercice

PLACE 0,0,NORTH

MOVE

REPORT

	Output: 0,1,NORTH
	
PLACE 0,0,NORTH

LEFT

REPORT

	Output: 0,0,WEST
	
PLACE 1,2,EAST

MOVE

MOVE

LEFT

MOVE

REPORT

Output: 3,3,NORTH

# trying to place robot outside the tabletop

place 7,7,north

Output: Not a valid command! Please try again.
  
# trying to move robot outside the tabletop

place 4,4,east

move

Output: This move will make the robot fall! Please try again
  
# trying to call any command without valid PLACE executed

move

Output: No valid Place command previously executed! Please try again

left

Output: No valid Place command previously executed! Please try again

right

Output: No valid Place command previously executed! Please try again

report

Output: No valid Place command previously executed! Please try again
  
# entering unsupporting command

place 1,1

Output: Not a valid command! Please try again.

place 1,2,3,north

Output: Not a valid command! Please try again.

place 0,0,noorth

Output: Not a valid command! Please try again.

go left

Output: Not a valid command! Please try again.

# exit the application

exit

Output: application has closed
	
