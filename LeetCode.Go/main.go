package main

import (
	"fmt"
	"sort"
)

func main() {
	fmt.Print("Hello World!")
}

// 3467. Transform Array by Parity
func transformArray(nums []int) []int {
	var result []int

	for _, num := range nums {
		if num%2 == 0 {
			result = append(result, 0)
		} else {
			result = append(result, 1)
		}
	}
	sort.Ints(result)
	return result
}

// 3340. Check Balanced String
func isBalanced(num string) bool {
	var oddSum, evenSum int
	oddSum = 0
	evenSum = 0

	for i := 0; i < len(num); i++ {
		if i%2 == 0 {
			evenSum += int(num[i] - '0')
		} else {
			oddSum += int(num[i] - '0')
		}
	}

	return oddSum == evenSum
}

func maxContainers(n int, w int, maxWeight int) int {
	if n*n > maxWeight/w {
		return maxWeight / w
	} else {
		return n * n
	}

	// worst time
	//i := n * n
	//for i > 0 && i*w > maxWeight {
	//	i--
	//}
	//return i;
}

// Anotações
// fmt.Scanln(&nome) -> Lê uma linha de entrada do usuário e armazena na variável nome

// len(num) -> Retorna o comprimento da string num
