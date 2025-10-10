## K8S

### Deployement Kind
- Deployment vs PODs vs StatefulSet
- Deployment Give you Random Name
- StatefulSet gives you Meaning full names

| Aspect                | Deployment      | StatefulSet                            |
| --------------------- | --------------- | -------------------------------------- |
| **Performance**       | ✅ Same          | ✅ Same                                 |
| **Scaling**           | ✅ Auto          | ✅ Auto, but with predictable naming    |
| **Rolling updates**   | ✅ Graceful      | ✅ Graceful                             |
| **Recovery**          | ✅ Auto recreate | ✅ Auto recreate                        |
| **Pod naming**        | Random suffix    | ✅ `rabbitmq-0`, `rabbitmq-1` (stable)  |
| **Volume binding**    | Shared (or PVC) | ✅ Stable PVC per pod                   |
| **Cluster formation** | 🟡 Manual       | ✅ Easier for clustered RabbitMQ setups |

### Deployment = stateless, easy scaling.
- StatefulSet = stable identity, persistent storage.
- RabbitMQ, Redis, databases = StatefulSet is the right choice. 💯