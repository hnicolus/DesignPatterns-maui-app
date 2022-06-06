# Strategy Design Pattern

The strategy pattern (also known as the policy pattern) is a behavioral software design pattern that enables selecting an algorithm at runtime. Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.
## Implementation

We are going to create a Strategy interface defining an action and concrete strategy classes implementing the Strategy interface. Context is a class which uses a Strategy.

StrategyPatternDemo, our demo class, will use Context and strategy objects to demonstrate change in Context behaviour based on strategy it deploys or uses

- Step 1
  Create an interface.
  
  ```
  public interface Strategy {
   public int doOperation(int num1, int num2);
  }
  ```

- Step 2
  Create concrete classes implementing the same interface.

  ```
  public class OperationAdd implements Strategy{
     @Override
     public int doOperation(int num1, int num2) {
        return num1 + num2;
     }
  }
  ```
  
  ```
  //OperationSubstract.java
  public class OperationSubstract implements Strategy{
   @Override
   public int doOperation(int num1, int num2) {
      return num1 - num2;
   }
  }
  ```

  ```
  //OperationMultiply.java

  public class OperationMultiply implements Strategy{
     @Override
     public int doOperation(int num1, int num2) {
        return num1 * num2;
     }
  }
  ```

