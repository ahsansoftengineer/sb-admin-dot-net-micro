| Field                          | `Auth` Value                   | `Hierarchy` Value                   |
| ------------------------------ | ------------------------------ | ----------------------------------- |
| StatefulSet Name                | `depl-mssql-auth`          | `depl-mssql-hierarchy`          |
| PVC Claim Name                 | `claim-mssql-auth`         | `claim-mssql-hierarchy`         |
| ClusterIP Service Name         | `srvc-cip-mssql-auth`    | `srvc-cip-mssql-hierarchy`    |
| LoadBalancer Service Name      | `srvc-lb-mssql-auth` | `srvc-lb-mssql-hierarchy` |
| `app` Label (Deployment + Svc) | `mssql`                        | `mssql-hierarchy`                   |
| `matchLabels` in services      | `app: mssql`                   | `app: mssql-hierarchy`              |
