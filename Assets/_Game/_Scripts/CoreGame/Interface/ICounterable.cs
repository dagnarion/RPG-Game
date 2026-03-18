using UnityEngine;

public interface ICounterable
{
  public bool CanCounter { get; }
  public void HandleCounter();
}
