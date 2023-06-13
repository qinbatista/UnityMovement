# Object Movement

Status: Code

### RidigBody Movement

- The object is moved by physical calculation, it is good if the object wants the physical feeling of assimilation and interacts with each other without manual write codes for other objects.

```csharp
_rigidbody.AddForce(force);
```

```csharp
_rigidbody.velocity = velocity;
```

- If the object is Kinematic and doesn’t move with physical force, the object still can be moved manually.

```csharp
_rigidbody.MovePosition(transform.position + movement);
```

### Transform Movement

- Use the Unity provided property `Transform` to set the position or rotation, it is easy to use and you can set the position or rotation manually or using Unity provided function to avoid writing physical calculations.

```csharp
transform.Translate(direction * _speed * Time.deltaTime, Space.Self);
```

- Set Position directly

```csharp
transform.position = transform.position + direction * _speed * Time.deltaTime;
```

- Use Mathematical calculation to set the position

```csharp
transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
```# UnityMovement
