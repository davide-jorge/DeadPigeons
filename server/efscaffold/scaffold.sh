dotnet ef dbcontext scaffold \
  "Host=ep-gentle-term-a4savj6o-pooler.us-east-1.aws.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_2gdsDUHtbx7W; SSL Mode=VerifyFull; Channel Binding=Require;" \
  Npgsql.EntityFrameworkCore.PostgreSQL \
  --output-dir ./Models \
  --context-dir . \
  --context MyDbContext \
  --no-onconfiguring \
  --schema dead_pigeons \
  --force